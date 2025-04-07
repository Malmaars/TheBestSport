// EnemyStatsReferenceDrawer.cs
using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.Reflection;

[CustomPropertyDrawer(typeof(Ability), true)]
public class AbilityDrawer : PropertyDrawer
{
    private static Type[] abilityTypes;
    private static string[] abilityTypeNames;

    static AbilityDrawer()
    {
        var baseType = typeof(Ability);
        var types = new List<Type>();
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            try
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.IsSubclassOf(baseType) && !type.IsAbstract)
                    {
                        types.Add(type);
                    }
                }
            }
            catch { } // Some assemblies might throw — ignore them
        }

        abilityTypes = types.ToArray();
        abilityTypeNames = Array.ConvertAll(abilityTypes, t => t.Name);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, true) + 30;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect dropdownRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

        // Draw type selector
        int currentTypeIndex = -1;
        if (property.managedReferenceValue != null)
        {
            Type currentType = property.managedReferenceValue.GetType();
            currentTypeIndex = Array.FindIndex(abilityTypes, t => t == currentType);
        }

        int selectedIndex = EditorGUI.Popup(dropdownRect, "Type", currentTypeIndex, abilityTypeNames);

        if (selectedIndex != currentTypeIndex)
        {
            Type newType = abilityTypes[selectedIndex];
            property.managedReferenceValue = Activator.CreateInstance(newType);
        }

        // Draw the actual fields
        if (property.managedReferenceValue != null)
        {
            SerializedProperty iterator = property.Copy();
            iterator.NextVisible(true); // Skip generic field

            Rect fieldsRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + 4, position.width, position.height);
            EditorGUI.indentLevel++;
            EditorGUI.PropertyField(fieldsRect, property, true);
            EditorGUI.indentLevel--;
        }
    }
}

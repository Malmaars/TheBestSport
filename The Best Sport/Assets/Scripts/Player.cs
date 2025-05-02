using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody rb;

    bool grounded;
    public float minGroundDotProduct;

    public List<Character> myCharacters;
    Character currentCharacter;

    public PlayerInput playerInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        if (currentCharacter != null)
        {
            currentCharacter.grounded = grounded;
            currentCharacter.LogicUpdate();
        }

        else
            SwitchCharacter(0);
    }

    void SwitchCharacter(int _index)
    {
        Character newChar = myCharacters[_index];

        if (newChar == null || newChar == currentCharacter)
            return;
        
        if (currentCharacter != null)
            currentCharacter.Disable();

        currentCharacter = newChar;
        currentCharacter.Initialize(playerInput, rb);   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!this.enabled)
            return;
        //onGround = true;
        EvaluateCollision(collision);

        //get knockback from whatever you touch
        //if(collision.rigidbody != null) 
        //rb.linearVelocity = -collision.rigidbody.linearVelocity;
    }

    private void OnDrawGizmos()
    {
        if (!this.enabled) return;

        if (currentCharacter != null)
            currentCharacter.DrawGizmos();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!this.enabled) return;
        EvaluateCollision(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!this.enabled) return;
        EvaluateCollision(collision);
    }
    void EvaluateCollision(Collision collision)
    {
        int groundContactCount = 0;
        Vector2 contactNormal = new Vector2();

        for (int i = 0; i < collision.contactCount; i++)
        {
            Vector2 normal = collision.GetContact(i).normal;
            if (normal.y >= minGroundDotProduct)
            {
                groundContactCount++;
                contactNormal += normal;
            }
        }
        if (groundContactCount > 1)
            contactNormal.Normalize();
        //else if (groundContactCount == 0)
        //    contactNormal = Vector3.zero;

        if (groundContactCount > 0)
            grounded = true; else grounded = false;
    }
}

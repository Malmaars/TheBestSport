using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    bool grounded;
    public float minGroundDotProduct;

    public List<Character> myCharacters;
    Character currentCharacter;

    PlayerInput playerInput;

    private void Awake()
    {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!this.enabled)
            return;
        //onGround = true;
        EvaluateCollision(collision);

        //get knockback from whatever you touch
        //if(collision.rigidbody != null) 
        //rb.linearVelocity = -collision.rigidbody.linearVelocity;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!this.enabled) return;
        EvaluateCollision(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!this.enabled) return;
        EvaluateCollision(collision);
    }
    void EvaluateCollision(Collision2D collision)
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

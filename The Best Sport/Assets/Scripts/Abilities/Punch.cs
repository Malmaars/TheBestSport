using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class Punch : Ability
{
    public float punchPower;
    public float punchRange;

    Vector2 lastInputDirection;

    GameObject debugCube;


    public Punch() : base() { }
    public Punch(Ability reference) : base(reference) { }

    //hit anything hittable in the direction you're aiming

    public override void PerformOnUpdate()
    {
        if(debugCube != null)
        {
            Vector3 hitboxPosition = myCharacter.rb.position + new Vector3((lastInputDirection * (punchRange / 2)).x, (lastInputDirection * (punchRange / 2)).y, 0);
            Vector3 hitboxSize = new Vector3(0.2f, punchRange, 0.1f);
            Quaternion punchRotation = Quaternion.Euler(0, 0, Mathf.Atan2(lastInputDirection.y, lastInputDirection.x) * Mathf.Rad2Deg + 90);
            debugCube.transform.position = hitboxPosition;
            debugCube.transform.localScale = hitboxSize;
            debugCube.transform.rotation = punchRotation;
        }
    }
    //input for punching
    public override void PerformOnInput(InputAction.CallbackContext context)
    {
        Debug.Log("Punch");
        //get input direction
        if(lastInputDirection != null && lastInputDirection != Vector2.zero) 
        {
            //punch in the last input direction
            Vector3 hitboxPosition = myCharacter.rb.position + new Vector3((lastInputDirection * (punchRange / 2)).x, (lastInputDirection * (punchRange / 2)).y, 0);
            Vector3 hitboxSize = new Vector3(0.2f, punchRange, 0.5f);
            Quaternion punchRotation = Quaternion.Euler(0, 0, Mathf.Atan2(lastInputDirection.y, lastInputDirection.x) * Mathf.Rad2Deg + 90);
            Collider[] hitColliders = Physics.OverlapBox(hitboxPosition, hitboxSize, punchRotation);

            foreach(Collider collider in hitColliders)
            {
                if(collider.gameObject.tag == "Ball")
                {
                    Debug.Log("Punching Ball");
                    //give a velocity to the ball   
                    collider.attachedRigidbody.linearVelocity = lastInputDirection * punchPower;
                }
            }
        }
    }
    //movement input
    public override void PerformOnSecondaryInput(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>() == Vector2.zero)
            return;

        lastInputDirection = context.ReadValue<Vector2>().normalized;

        if (debugCube == null)
        {
            debugCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            debugCube.GetComponent<Collider>().enabled = false;
        }
    }
}

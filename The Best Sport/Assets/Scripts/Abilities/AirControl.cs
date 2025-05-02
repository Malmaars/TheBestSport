using UnityEngine;
using UnityEngine.InputSystem;

public class AirControl : Ability
{ 
    public float maxSpeed;
    public float moveSpeed;
    Vector2 moveInput;

    public AirControl() : base() { }

    public AirControl(Ability reference) : base(reference) { }

    public override void PerformOnUpdate()
    {
        if (myCharacter.grounded)
            return;

        if (myCharacter.rb.linearVelocity.x > maxSpeed && moveInput.x > 0 || myCharacter.rb.linearVelocity.x < -maxSpeed && moveInput.x < 0)
            return;

        myCharacter.rb.linearVelocity += (new Vector3((moveInput.normalized).x * moveSpeed, 0));
    }

    public override void PerformOnInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        moveInput.y = 0;
    }

    public override void PerformOnCancelInput(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
    }
}

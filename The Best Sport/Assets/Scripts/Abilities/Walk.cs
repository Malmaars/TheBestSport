using System;
using UnityEngine;

[Serializable]
public class Walk : Ability
{
    public float maxSpeed;
    public float moveSpeed;
    public override void PerformOnUpdate()
    {
        Vector2 moveInput = InputDistributor.playerControls.Player.Move.ReadValue<Vector2>();
        moveInput.y = 0;

        myCharacter.rb.linearVelocity = Vector2.MoveTowards(myCharacter.rb.linearVelocity, new Vector2((moveInput.normalized).x * maxSpeed, myCharacter.rb.linearVelocity.y), moveSpeed);
    }
}

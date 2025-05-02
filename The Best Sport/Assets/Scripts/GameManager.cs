using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    PlayerControls playerControls;
    InputManager playerInputManager;
    private void Awake()
    {
        playerControls = new PlayerControls();
        playerInputManager = new InputManager(
            new InputAction[]
            {
                playerControls.Player.Move,
                playerControls.Player.Jump,
                playerControls.Player.Attack,
                playerControls.Player.SwitchLeft,
                playerControls.Player.SwitchRight,
                playerControls.Player.Aim
            });

        InputDistributor.inputManager = playerInputManager;
        InputDistributor.playerControls = playerControls;
    }

    private void OnEnable()
    {
        playerInputManager.WhenEnabled();
    }

    private void OnDisable()
    {
        playerInputManager.WhenDisabled();
    }

}

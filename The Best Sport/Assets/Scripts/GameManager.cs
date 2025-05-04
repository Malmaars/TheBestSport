using UnityEngine;
using NaughtyAttributes;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [ReadOnly]
    public static GameManager instance;

    public GameObject ballPrefab;

    public GameObject currentBall;

    PlayerControls playerControls;
    InputManager playerInputManager;
    private void Awake()
    {
        // Set instance and make sure there's only one
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject); // Prevent duplicates
        

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

    public void SpawnBall()
    {
        Instantiate(ballPrefab, new Vector3(0,0,0), Quaternion.identity);
    }

    public void DeSpawnCurrentBall()
    {
        Destroy(currentBall);
    }

}

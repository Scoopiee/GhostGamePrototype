using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerPowersController _playerPowersController;
    
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private float speed;
    
    private float _originalOpacity;

    public float powerCharge;
    
    private InputAction _moveAction;
    private InputAction _interactAction;
    private InputAction _pauseAction;
    private InputAction _invisibilityAction;
    
    private Vector2 _moveInput = Vector2.zero;
    private bool _interact;
    private bool _pause;
    private bool _invisible;
    
    
    private float _yDirection;
    private float _xDirection;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerPowersController = GetComponent<PlayerPowersController>();
        
    }

    private void Start()
    {
        // Check for WASD (or controller) movement
        _moveAction = InputSystem.actions.FindAction("Move");
        // Check for E key (or north button on controller) press
        _interactAction = InputSystem.actions.FindAction("Interact");
        // Check for Escape key (or start button on controller) press
        _pauseAction = InputSystem.actions.FindAction("Pause");
        _invisibilityAction = InputSystem.actions.FindAction("Invisibility");
    }

    private void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();
        if (_interactAction.triggered) Interact();
            
        
        /*
        if (_pauseAction.triggered)
        {
            if (pauseMenu.paused)
            {
                pauseMenu.ResumeGame();
            }
            else
            {
                pauseMenu.PauseGame();
            }
        }
        */
        
        if (_invisibilityAction.triggered) _playerPowersController.GoInvisible();
}

    private void FixedUpdate()
    {
        //_rb.linearVelocity = _moveInput * speed;
        _rb.AddForce(_moveInput * speed);
        
    }

    private void Interact()
    {
        Debug.Log("Interact");
        // TODO: Make an interact function which hides a player if hiding spot in certain range
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            IItem pickup = other.gameObject.GetComponent<IItem>();
            if (pickup != null)
            {
                pickup.OnPickUp(gameObject);
            }
        }
        
    }



    
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private float speed;
    
    
    private InputAction _moveAction;
    private InputAction _interactAction;
    private InputAction _pauseAction;
    
    private Vector2 _moveInput = Vector2.zero;
    private bool _interact;
    private bool _pause;
    
    private Rigidbody2D _rb;
    
    
    private float _yDirection;
    private float _xDirection;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        // Check for WASD (or controller) movement
        _moveAction = InputSystem.actions.FindAction("Move");
        // Check for E key (or north button on controller) press
        _interactAction = InputSystem.actions.FindAction("Interact");
        // Check for Escape key (or start button on controller) press
        _pauseAction = InputSystem.actions.FindAction("Pause");
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
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            // TODO: Add the object collided with to player's inventory (removing item from map)

        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerPowersController _playerPowersController;
    
    [SerializeField] private IInteractable interactableTarget = null;
    [SerializeField] private float speed;
    
    public InputAction moveAction;
    private InputAction _interactAction;
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
        moveAction = InputSystem.actions.FindAction("Move");
        // Check for E key (or north button on controller) press
        _interactAction = InputSystem.actions.FindAction("Interact");
        
        _invisibilityAction = InputSystem.actions.FindAction("Invisibility");
        
        // Check for Escape key (or start button on controller) press
        //_pauseAction = InputSystem.actions.FindAction("Pause");
    }

    private void Update()
    {
        _moveInput = moveAction.ReadValue<Vector2>();
        if (_interactAction.triggered && interactableTarget != null) Interact(interactableTarget);
        if (_invisibilityAction.triggered) _playerPowersController.GoInvisible();
        
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

    private void Interact(IInteractable interactable)
    {
        interactable.Interact();
        print("Interacting with " + ((MonoBehaviour)interactable).gameObject.name);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            IItem pickup = other.gameObject.GetComponent<IItem>();
            if (pickup != null)
            {
                pickup.OnPickUp(_playerPowersController);
            }
        }
        
        // TODO: Add an interactable tag so that it only searches for a component if object is interactable to improve performance
        if (other.gameObject.TryGetComponent(out IInteractable interactable)) // check if the target has an Interactable component
        {
            interactableTarget = interactable;
        }
        
    }
    
    private void OnTriggerExit2D(Collider2D other) // use colliders to find stuff to not want to interact with anymore because we learn to live and let go
    {
        if (other.gameObject.GetComponent<IInteractable>() != null) // check if the target has an Interactable component
        {
            interactableTarget = null; // if not, set to null
        }
    }
}


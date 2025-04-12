using UnityEngine;
using UnityEngine.InputSystem;

public class TempPlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject target = null;

    
    public InputAction _moveAction;
    private InputAction _interactAction;
    private Vector2 _moveInput = Vector2.zero;
    
    private Rigidbody2D _rb;
    
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
    }

    private void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();

        if (_interactAction.triggered && target != null)
        {
            Interact(target);
        }
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _moveInput * speed;
    }

    private void Interact(GameObject target)
    {
        if (target.TryGetComponent(out Interactable interactable)) // check if the target has an Interactable component
        {
            interactable.Interact();
            print("Interacting with " + target.name);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) // use colliders to find stuff to interact with 
    {
        target = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other) // use colliders to find stuff to not want to interact with anymore because we learn to live and let go
    {
        target = null;
    }
    
}
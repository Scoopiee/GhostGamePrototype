using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.InputSystem;

public class TempPlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Interactable interactableTarget = null;

    
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

        if (_interactAction.triggered && interactableTarget != null)
        {
            Interact(interactableTarget);
        }
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _moveInput * speed;
    }

    private void Interact(Interactable interactable)
    {
        interactable.Interact();
        print("Interacting with " + interactable.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other) // use colliders to find stuff to interact with 
    {
        if (other.gameObject.TryGetComponent(out Interactable interactable)) // check if the target has an Interactable component
        {
            interactableTarget = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D other) // use colliders to find stuff to not want to interact with anymore because we learn to live and let go
    {
        if (other.gameObject.GetComponent<Interactable>() != null) // check if the target has an Interactable component
        {
            interactableTarget = null; // if not, set to null
        }
    }
    
}
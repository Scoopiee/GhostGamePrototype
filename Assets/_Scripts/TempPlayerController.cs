using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TempPlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private InputAction _moveAction;
    private InputAction _interactAction;
    
    private Vector2 _moveInput = Vector2.zero;
    private bool _interact;
    
    private Rigidbody2D _rb;
    
    private float _yDirection;
    private float _xDirection;
    private GameObject target;  

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

        if (_interactAction.triggered)
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
        // Check if the target is interactable
        if (target.TryGetComponent(out Interactable interactable))
        {
            interactable.Interact();
            print("Interacting with " + target.name);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        target = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        target = null;
    }
}
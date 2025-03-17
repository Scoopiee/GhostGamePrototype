using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private InputAction _moveAction;
    private InputAction _interactAction;
    
    private Vector2 _moveInput = Vector2.zero;
    private bool _interact;
    
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
    }

    private void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();

        if (_interactAction.triggered)
        {
            Interact();
        }
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _moveInput * speed;
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

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private InputAction _moveAction;
    private Vector2 _moveInput = Vector2.zero;
    
    private Rigidbody2D _rb;
    
    private float _yDirection;
    private float _xDirection;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _moveInput * speed;
    }
}

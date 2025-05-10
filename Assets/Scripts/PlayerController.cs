using System.Collections;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private Slider slider;
    [SerializeField] private float speed;
    [SerializeField, Range(0f, 1f)]private float opacityWhenInvisible;
    [SerializeField] private float invisibilityDuration;
    [SerializeField, Range(0f, 100f)] private float invisibilityCost;
    
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
    
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    
    
    private float _yDirection;
    private float _xDirection;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        
        _originalOpacity = _sr.color.a;
        
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
        if (!pauseMenu.paused)
        {
            _moveInput = _moveAction.ReadValue<Vector2>();

            if (_interactAction.triggered) Interact();
            
            
        }
        
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
        
        if (_invisibilityAction.triggered) GoInvisible();
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

    private void GoInvisible()
    {
        if (!_invisible && powerCharge >= invisibilityCost)
        {
            SubtractFromPowerCharge(10);
            
            Color currentColor = _sr.color;

            currentColor.a = opacityWhenInvisible;

            _sr.color = currentColor;

            Debug.Log("GoInvisible");

            StartCoroutine(RevertVisibilityAfterDelay(invisibilityDuration));
        } 
        else if (powerCharge < invisibilityCost)
        {
            // TODO: Animation to show not enough power
        }
    }
    
    private IEnumerator RevertVisibilityAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        Color currentColor = _sr.color;
        currentColor.a = _originalOpacity;
        _sr.color = currentColor;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            IItem pickup = other.gameObject.GetComponent<IItem>();
            if (pickup != null)
            {
                pickup.OnPickUp(this);
            }
        }
        
    }


    public void AddToPowerCharge(float powerToAdd)
    {
        if (powerCharge + powerToAdd > slider.maxValue)
        {
            // TODO: Add an animation to slider to show power is full
        }
        else
        {
            powerCharge += powerToAdd;
            slider.value = powerCharge;
        }
        
    }

    public void SubtractFromPowerCharge(float powerToSubtract)
    {
        if (powerCharge - powerToSubtract < slider.minValue)
        {
            powerCharge = slider.minValue;
        }
        else
        {
            powerCharge -= powerToSubtract;
        }
        
        slider.value = powerCharge;
    }
}

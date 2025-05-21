using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    public bool isHidden = false;
    public bool isInVent = false;
    public Vent currentVent;
    private PlayerMovementController _playerMovementController;
    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        _playerMovementController = GetComponent<PlayerMovementController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Hide() // Disables movement and hides sprite
    {
        _playerMovementController.moveAction.Disable();
        _spriteRenderer.enabled = false; 
        isHidden = true;
        
    }
    public void Unhide()
    {
        _playerMovementController.moveAction.Enable(); // Enables the move action
        _spriteRenderer.enabled = true; // Shows the sprite
        isHidden = false;
        
    }
}

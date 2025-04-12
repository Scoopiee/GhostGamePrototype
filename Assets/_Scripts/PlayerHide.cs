using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    public bool isHidden = false;
    private TempPlayerController _playerController;
    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        _playerController = GetComponent<TempPlayerController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Hide() // Disables movement and hides sprite
    {
        _playerController._moveAction.Disable();
        
        _spriteRenderer.enabled = false; 
        
    }
    public void Unhide()
    {
        _playerController._moveAction.Enable(); // Enables the move action
        
        _spriteRenderer.enabled = true; // Shows the sprite
        
    }
}

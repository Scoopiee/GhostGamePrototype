using UnityEngine;

public class HidingSpot : MonoBehaviour, IInteractable
{
    private GameObject player;
    private PlayerHide playerHide; // Reference to the PlayerHide script
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHide = player.GetComponent<PlayerHide>();
    }
    public void Interact() // Inherited from Interactable interface
    {
        if (playerHide.isHidden == false)
        {
          playerHide.Hide();
        }
        else if (playerHide.isHidden == true)
        {
          playerHide.Unhide();
        }
    }
}


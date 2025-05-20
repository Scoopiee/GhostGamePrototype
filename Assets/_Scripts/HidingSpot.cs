using UnityEngine;

public class HidingSpot : Interactable
{
    private GameObject player;
    private PlayerHide playerHide; // Reference to the PlayerHide script
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHide = player.GetComponent<PlayerHide>();
    }
    public override void Interact() // Overridden from Interactable abstract class
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


using UnityEngine;

public class HidingSpot : Interactable
{
    public override void Interact() // Overridden from Interactable abstract class
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerHide playerHide = player.GetComponent<PlayerHide>();

        if (playerHide.isHidden == false)
        {
          playerHide.Hide();
          playerHide.isHidden = true;
        }
        else if (playerHide.isHidden == true)
        {
          playerHide.Unhide();
          playerHide.isHidden = false;
        }
    }
}


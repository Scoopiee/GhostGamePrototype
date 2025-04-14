using System.Runtime.CompilerServices;
using UnityEngine;

public class Vent : Interactable
{
    private GameObject player; //player object
    private PlayerHide playerHide; //player hide script
    private SpriteRenderer spriteRenderer; //sprite renderer for the vent object
    private Color ventColour; //colour of the vent object
    void Awake()
    {   
        player = GameObject.FindGameObjectWithTag("Player"); //finds the player object in the scene
        
        if (player != null)
        {
            playerHide = player.GetComponent<PlayerHide>(); //gets playerhide script from player
            if (playerHide == null)
            {
                Debug.LogError("PlayerHide script not found on player object");
            } 
        }
        else
        {
            Debug.LogError("Player object not assigned");
        }

        spriteRenderer = GetComponent<SpriteRenderer>(); //gets the sprite renderer component of the vent object
       
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on vent object");
        }
    }
    void Start()
    {
        ventColour = spriteRenderer.color; //gets the current colour of the vent 
    }
    public override void Interact()
    {
        if (playerHide.isHidden == false) //player entering the vent
        {
            EnterVent();
        }
        else if (playerHide.isHidden == true) //player leaving the vent
        {
            ExitVent();
        }
   }
    
    private void OnMouseDown() //called when player clicks any vent
    {
        if (playerHide.isInVent == true)
        {
            player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            
            ExitVent();
        }
    }

    private void OnMouseEnter()
    {
        if (playerHide.isInVent == true)
        {
            spriteRenderer.color = new Color(ventColour.r, ventColour.g, ventColour.b, 0.5f); //make sprite transparent
        }
    }

    private void OnMouseExit()
    {
        {
            spriteRenderer.color = ventColour; //reset sprite colour to original
        }
    }    

    private void EnterVent()
    {
        playerHide.Hide();
        playerHide.isInVent = true;
    }

    private void ExitVent()
    {
        playerHide.Unhide();
        playerHide.isInVent = false; 
        
    }
}
//TODO: handle instance seperation of vents for more reliable behaviour 
//TODO: Raycasting and layer masks for highlighting vents  
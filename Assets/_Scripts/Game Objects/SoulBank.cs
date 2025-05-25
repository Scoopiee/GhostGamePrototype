using UnityEngine;

public class SoulBank : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerInventoryController playerInventory;
    
    public void Interact()
    {
        playerInventory.GiveSouls(this);
    }
}

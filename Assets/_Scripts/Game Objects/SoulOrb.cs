using UnityEngine;

public class SoulOrb : MonoBehaviour, IItem
{
    [SerializeField] public int scoreValue;
    
    public void OnPickUp(GameObject player)
    {
        // TODO: add an inventory system to drop show which souls have been collected by the player, to be returned to spawn point?
        player.GetComponent<PlayerInventoryController>().AddSoulOrb(this);
        GameManager.Instance.score += 5;
        Destroy(gameObject);
    }
}

using System;
using UnityEngine;

public class SoulOrb : MonoBehaviour, IItem
{
    public SoulOrbData soulOrbData;
    private SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.color = soulOrbData.spriteColour;
    }

    public void OnPickUp(GameObject player)
    {
        // TODO: add an inventory system to drop show which souls have been collected by the player, to be returned to spawn point?
        player.GetComponent<PlayerInventoryController>().AddSoulOrb(soulOrbData);
        
        if (UIManager.instance.soulOrbUIDictionary.TryGetValue(soulOrbData, out SoulOrbToCollectInfo uiElement))
        {
            uiElement.CollectedSoul();
        }
        
        GameManager.Instance.AddToScore(soulOrbData.scoreValue);
        Destroy(gameObject);
    }
}

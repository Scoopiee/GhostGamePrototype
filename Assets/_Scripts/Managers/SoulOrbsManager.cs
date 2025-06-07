using System.Collections.Generic;
using UnityEngine;

public class SoulOrbsManager : MonoBehaviour
{
    public Dictionary<SoulOrbData, SoulOrbToCollectInfo> soulOrbUIDictionary;
    
    void Start()
    {
        
        soulOrbUIDictionary = new Dictionary<SoulOrbData, SoulOrbToCollectInfo>();
    
    }
    
    public void InitializeDictionary(GameObject inventoryPanel)
    {
        
        soulOrbUIDictionary.Clear();
        SoulOrbToCollectInfo[] allSoulOrbPanels = inventoryPanel.GetComponentsInChildren<SoulOrbToCollectInfo>(true);
        
        foreach (SoulOrbToCollectInfo soulOrb in allSoulOrbPanels)
        {
            if (soulOrb.soulOrbData != null)
            {
                soulOrbUIDictionary[soulOrb.soulOrbData] = soulOrb;
            }
        }
    }
}

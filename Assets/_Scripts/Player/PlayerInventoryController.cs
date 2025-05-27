using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    private List<SoulOrbData> _soulOrbs  = new List<SoulOrbData>();


    public void AddSoulOrb(SoulOrbData soulOrbData)
    {
        _soulOrbs.Add(soulOrbData);
        Debug.Log("Soul Orb Added" + _soulOrbs.Count);
    }
    
    
    public void GiveSouls(SoulBank soulBank)
    {
        foreach (SoulOrbData orbData in _soulOrbs)
        {
            // TODO: Animation of soul bank for each orb, maybe particles fire
            Debug.Log("Soul Orb Given To Bank");
            GameManager.Instance.score += orbData.scoreValue;
            
        }
        _soulOrbs.Clear();
        Debug.Log(_soulOrbs.Count);
    }
}

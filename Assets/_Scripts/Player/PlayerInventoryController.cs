using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    private List<SoulOrb> _soulOrbs;


    public void AddSoulOrb(SoulOrb soulOrb)
    {
        _soulOrbs.Add(soulOrb);
        Debug.Log("Soul Orb Added" + _soulOrbs.Count);
    }
    
    
    public void GiveSouls(SoulBank soulBank)
    {
        foreach (SoulOrb orb in _soulOrbs)
        {
            // TODO: Animation of soul bank for each orb, maybe particles fire
            Debug.Log("Soul Orb Given To Bank");
            GameManager.Instance.score += orb.scoreValue;
            
        }
        _soulOrbs.Clear();
        Debug.Log(_soulOrbs.Count);
    }
}

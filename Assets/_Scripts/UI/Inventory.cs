using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject sceneSoulList;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject soulOrbToCollectPanelPrefab;

    [SerializeField] private float verticalSpacing;
    [SerializeField] private float startYOffset;
    [SerializeField] private float startXOffset;
    
    private List<SoulOrbData> _soulsToCollect = new List<SoulOrbData>();

    private void Start()
    {
        float currentY = startYOffset;
        
        foreach (SoulOrb child in sceneSoulList.GetComponentsInChildren<SoulOrb>())
        {
            _soulsToCollect.Add(child.soulOrbData);
            GameObject newPanel = Instantiate(soulOrbToCollectPanelPrefab, gameObject.transform);
            RectTransform rt = newPanel.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(startXOffset, -currentY);
            
            
            currentY += rt.sizeDelta.y + verticalSpacing;
        }
        
        
        
    }
}

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

    private GameObject _tempPanel;
    private RectTransform _rt;

    private void Start()
    {
        float currentY = startYOffset;
        
        foreach (SoulOrb child in sceneSoulList.GetComponentsInChildren<SoulOrb>())
        {
            _soulsToCollect.Add(child.soulOrbData); // Add children of the list of souls to the list needed to collect
            _tempPanel = Instantiate(soulOrbToCollectPanelPrefab, gameObject.transform); // Create a new panel for each soul
            _rt = _tempPanel.GetComponent<RectTransform>(); 
            _rt.anchoredPosition = new Vector2(startXOffset, -currentY); // Move the position of the soul panel

            _tempPanel.GetComponent<SoulOrbToCollectInfo>().AddData(child.soulOrbData);
            
            currentY += _rt.sizeDelta.y + verticalSpacing;
        }
        
        UIManager.instance.soulOrbsManager.InitializeDictionary(gameObject);
        
    }
}

using System;
using UnityEngine;

public class Battery : MonoBehaviour, IItem
{
    [SerializeField] private float powerInBattery;
    
    public void OnPickUp(PlayerController player)
    {
        player.powerCharge += powerInBattery;
        player.SetPowerChargeOnSlider();
        Destroy(gameObject);
    }
}

using System;
using UnityEngine;

public class Battery : MonoBehaviour, IItem
{
    [SerializeField] private float powerInBattery;
    
    public void OnPickUp(PlayerPowersController player)
    {
        player.AddToPowerCharge(powerInBattery);
        Destroy(gameObject);
    }
}

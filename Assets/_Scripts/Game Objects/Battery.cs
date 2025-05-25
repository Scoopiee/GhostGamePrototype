using System;
using UnityEngine;

public class Battery : MonoBehaviour, IItem
{
    [SerializeField] private float powerInBattery;
    
    public void OnPickUp(GameObject player)
    {
        player.GetComponent<PlayerPowersController>().AddToPowerCharge(powerInBattery);
        Destroy(gameObject);
    }
}

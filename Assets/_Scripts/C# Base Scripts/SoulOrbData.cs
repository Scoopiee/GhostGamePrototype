using UnityEngine;

[CreateAssetMenu(fileName = "SoulOrbData", menuName = "Scriptable Objects/SoulOrbData")]
public class SoulOrbData : ScriptableObject
{
    [Tooltip("The name of the ghost which will appear in the inventory")] public string ghostName;
    public int scoreValue;
    public Color spriteColour;
    // Add any value which is needed to be kept in inventory after item is removed
    
    // public Sprite soulOrbSprite;
}

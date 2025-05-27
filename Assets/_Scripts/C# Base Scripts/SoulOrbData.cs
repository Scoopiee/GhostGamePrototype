using UnityEngine;

[CreateAssetMenu(fileName = "SoulOrbData", menuName = "Scriptable Objects/SoulOrbData")]
public class SoulOrbData : ScriptableObject
{
    public string ghostName;
    public int scoreValue;
    // Add any value which is needed to be kept in inventory after item is removed
    // public Color spriteColour;
    // public Sprite soulOrbSprite;
}

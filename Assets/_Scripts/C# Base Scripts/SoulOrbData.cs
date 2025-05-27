using UnityEngine;

[CreateAssetMenu(fileName = "SoulOrbData", menuName = "Scriptable Objects/SoulOrbData")]
public class SoulOrbData : ScriptableObject
{
    public string soulOrbName;
    public int scoreValue;
    // Add any value which is needed to be kept in inventory after item is removed
}

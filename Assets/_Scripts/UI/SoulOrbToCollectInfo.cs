using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoulOrbToCollectInfo : MonoBehaviour
{
    public TextMeshProUGUI soulName;
    public Toggle collectedToggle;
    public Toggle dispensedToggle;
    public Image soulImage;

    public void AddData(SoulOrbData soulOrbData)
    {
        soulName.text = soulOrbData.name;
        soulImage.color = soulOrbData.spriteColour;
    }

    public void CollectedSoul()
    {
        collectedToggle.isOn = true;
    }

    public void DispensedSoul()
    {
        dispensedToggle.isOn = true;
    }
}

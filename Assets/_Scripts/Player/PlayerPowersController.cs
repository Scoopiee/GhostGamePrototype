using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerPowersController : MonoBehaviour
{
    private SpriteRenderer _sr;
    
    [SerializeField] private Slider slider;
    [SerializeField, Range(0f, 1f)]private float opacityWhenInvisible;
    [SerializeField] private float invisibilityDuration;
    [SerializeField, Range(0f, 100f)] private float invisibilityCost;
    
    public float powerCharge;
    
    private float _originalOpacity;
    private bool _invisible;
    
    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _originalOpacity = _sr.color.a;
    }
    
    
    public void GoInvisible()
    {
        if (!_invisible && powerCharge >= invisibilityCost)
        {
            SubtractFromPowerCharge(10);
            
            Color currentColor = _sr.color;

            currentColor.a = opacityWhenInvisible;

            _sr.color = currentColor;

            Debug.Log("GoInvisible");

            StartCoroutine(RevertVisibilityAfterDelay(invisibilityDuration));
        } 
        else if (powerCharge < invisibilityCost)
        {
            // TODO: Animation to show not enough power
        }
    }
    
    
    private IEnumerator RevertVisibilityAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        Color currentColor = _sr.color;
        currentColor.a = _originalOpacity;
        _sr.color = currentColor;
    }
    
    
    public void AddToPowerCharge(float powerToAdd)
    {
        if (powerCharge + powerToAdd > slider.maxValue)
        {
            // TODO: Add an animation to slider to show power is full
        }
        else
        {
            powerCharge += powerToAdd;
            slider.value = powerCharge;
        }
        
    }
    
    
    public void SubtractFromPowerCharge(float powerToSubtract)
    {
        if (powerCharge - powerToSubtract < slider.minValue)
        {
            powerCharge = slider.minValue;
        }
        else
        {
            powerCharge -= powerToSubtract;
        }
        
        slider.value = powerCharge;
    }
}

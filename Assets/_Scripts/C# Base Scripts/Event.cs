using UnityEngine;

[System.Serializable]
public class Event
{
    [SerializeField] private string eventName;
    [SerializeField] private string text;
    [SerializeField] private float eventDuration;
    
    public string EventName => eventName;
    public string Text => text;
    public float EventDuration => eventDuration;
}

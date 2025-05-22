using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool paused = false;
    
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private List<Event> events;
    
    private int _currentEventNumber = 0;
    private float _remainingTimeUntilNextEvent;
    
    private int _minutes;
    private int _seconds;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // destroy the other instance if it exists
        }
        else
        {
            Instance = this; // assign the current instance 
            DontDestroyOnLoad(gameObject);
        }
        
        
    }


    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (_remainingTimeUntilNextEvent > 0)
        {
            // Get current time
            _remainingTimeUntilNextEvent -= Time.deltaTime;
        }
        else if (_currentEventNumber <= events.Count)
        {
            _currentEventNumber++;
            _remainingTimeUntilNextEvent = events[_currentEventNumber].EventDuration;
        }
        else
        {
            _remainingTimeUntilNextEvent = 0;
        }
        
        // Convert current time to minutes and seconds
        _minutes = (int) _remainingTimeUntilNextEvent / 60;
        _seconds = (int) _remainingTimeUntilNextEvent % 60;
        // Print out current time in format 00:00
        timeText.text = events[_currentEventNumber].Text + $" {_minutes:00}:{_seconds:00}";
    }

    private void StartGame()
    {
        // Start the game logic, spawn enemies, etc.
        _remainingTimeUntilNextEvent = events[_currentEventNumber].EventDuration;

    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        paused = true;
        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        paused = false;
        Debug.Log("Game Resumed");
    }
}

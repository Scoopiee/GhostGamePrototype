using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool paused = false;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this); // destroy the other instance if it exists
        }
        else
        {
            instance = this; // assign the current instance 
        }
    }


    private void Start()
    {
        // Initialize game state, load resources, etc.
    }

    private void StartGame()
    {
        // Start the game logic, spawn enemies, etc.
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

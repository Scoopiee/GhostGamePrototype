using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameUICanvas;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject optionsMenuPanel;
    [SerializeField] private GameObject inventoryPanel;
    
    public SoulOrbsManager soulOrbsManager;
    
    private InputAction _pauseAction;
    private InputAction _inventoryAction;
    
    public static UIManager instance;
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

    void Start()
    {
        // Initialize UI elements 

        _pauseAction = InputSystem.actions.FindAction("Pause");
        _inventoryAction = InputSystem.actions.FindAction("Inventory");

    }
    void Update()
    {
        
        if (_pauseAction.triggered && pauseMenuPanel.activeSelf == false)
        {
            Debug.Log("Pause Menu Triggered (on) (UIManager)");
            ShowPanel(pauseMenuPanel);
            GameManager.Instance.PauseGame();
        }
        else if (_pauseAction.triggered && pauseMenuPanel.activeSelf == true)
        {
            Debug.Log("Pause Menu Triggered (off) (UIManager)");
            HidePanel(pauseMenuPanel);
            GameManager.Instance.ResumeGame();
        }
        
        if (_inventoryAction.triggered && inventoryPanel.activeSelf == false)
        {
            Debug.Log("Inventory Panel Triggered (on) (UIManager)");
            ShowPanel(inventoryPanel);
            GameManager.Instance.PauseGame();
        }
        else if (_inventoryAction.triggered && inventoryPanel.activeSelf == true)
        {
            Debug.Log("Inventory Panel Triggered (off) (UIManager)");
            HidePanel(inventoryPanel);
            GameManager.Instance.ResumeGame();
        }
    }

    void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
        Debug.Log("Panel " + panel.name + " is now active.");
    }
    void HidePanel(GameObject panel)
        {
            panel.SetActive(false);
        }
    void togglePanel(GameObject panel)
        {
            panel.SetActive(!panel.activeSelf);
        }
    
    
}

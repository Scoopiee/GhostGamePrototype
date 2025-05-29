using UnityEngine;
using UnityEngine.InputSystem;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameUICanvas;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject optionsMenuPanel;
    [SerializeField] private GameObject inventoryPanel;
    private InputAction _pauseAction;
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
        // Initialize UI elements here

        _pauseAction = InputSystem.actions.FindAction("Pause");
    
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

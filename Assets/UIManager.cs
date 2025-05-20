using UnityEngine;
using UnityEngine.InputSystem;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameUICanvas;
    [SerializeField] private GameObject pauseMenuPanel;
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
       //gameUICanvas.SetActive(true); // Show the game UI canvas
       //pauseMenuPanel.SetActive(false); // Hide the pause menu panel}
        _pauseAction = InputSystem.actions.FindAction("Pause");
    
    }
    void Update()
    {
        if (_pauseAction.triggered)
        {
            togglePanel(pauseMenuPanel);
        }
    }

    void ShowPanel(GameObject panel)
        {
            panel.SetActive(true);
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

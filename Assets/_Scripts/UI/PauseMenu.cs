using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
   // public bool paused;
    
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    /*  
      public void PauseGame()
      {
          if (!optionsMenu.activeSelf)
          {
              pauseMenu.SetActive(true);
              Time.timeScale = 0f;
              paused = true;
          }
      }
      */ 

    /*
    public void ResumeGame()
    {
        if (!optionsMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            paused = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }
    }
    */
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

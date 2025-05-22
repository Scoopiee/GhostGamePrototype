using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Prototype Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

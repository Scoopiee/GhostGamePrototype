using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public Camera mainCamera;
    public Camera followCamera;

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
        SwitchToMainCamera(); // start with the main camera
    }

    public void SwitchToFollowCamera()
    {
        followCamera.gameObject.SetActive(true); 
        mainCamera.gameObject.SetActive(false); 
    }
    
    public void SwitchToMainCamera()
    {
        mainCamera.gameObject.SetActive(true); 
        followCamera.gameObject.SetActive(false); 
    }

}

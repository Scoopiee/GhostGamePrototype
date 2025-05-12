using UnityEngine;

public class SeekerMovement : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 5f; // Distance to detect the player
    private CircleCollider2D circleCollider; // Circle collider to visualize the detection radius
    private bool playerDetected = false; // Flag to check if the player is detected

    void Awake()
    {
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (circleCollider != null) // set its radius to the detection radius *not permanent, just for testing purposes*
        {
            circleCollider.radius = detectionRadius;
        }
        
        if (playerDetected) // If the player is detected
        {
            MoveToPlayer(); // Move towards the player
        }
    }
    void MoveToPlayer() // Move to player if the player has been 'seen' by the seeker
    {

    }

    private void OnTriggerEnter2D(Collider2D other) // Check if the player is within the detection radius
    {
        if (other.CompareTag("Player")) // If the player is detected
        {
            playerDetected = true; // Set the player detected flag to true
        }
    }
    private void OnTriggerExit2D(Collider2D other) // Check if the player is outside the detection radius
    {
        if (other.CompareTag("Player")) // If the player is no longer detected
        {
            playerDetected = false; // Set the player detected flag to false
        }
    }
}
/* TODO: Movement to player 
         Raycasting to check if the player is in line of sight (may require layermask stuff)
         Catch the player if they are touched by the seeker
*/
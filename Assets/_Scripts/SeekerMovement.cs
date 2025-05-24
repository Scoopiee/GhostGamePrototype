using UnityEditor.Callbacks;
using UnityEngine;

public class SeekerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private bool playerDetected = false; // Flag to check if the player is detected
    [SerializeField] private float detectionRadius = 5f; // Radius within which the seeker can detect the player
    [SerializeField] private GameObject player; // Radius within which the seeker can detect the player
    private Vector3 directionToPlayer;
    float distanceToPlayer; 


    void Awake()
    {

    }
    void Start()
    {

    }

    void Update()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized;
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        playerDetected = false; // assume player is not detected at the start of each frame
       
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, directionToPlayer, detectionRadius); // shoots a beam and returns a list of colliders

        foreach (var hit in hits)
        {
            if (hit.collider != null && hit.collider.gameObject == this.gameObject) // bypass self
                continue;

            if (hit.collider.CompareTag("Player"))
            {
                playerDetected = true;
            }

            break; //exit the loop after first hit is checked to be a player
        }

        if (playerDetected && distanceToPlayer >= 1.5f)  // if the player is detected and within a certain distance (so it doesn't run into player)
        {
            MoveToPlayer();
        }

        Debug.DrawRay(transform.position, directionToPlayer * detectionRadius, Color.red); // Draw a ray in the editor for debugging
        Debug.Log($"Distance to player: {distanceToPlayer}, Player Detected: {playerDetected} Raycast Hit: {hits}");
    }

    void MoveToPlayer() // Move to player if the player has been 'seen' by the seeker
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }
    
    void OnDrawGizmosSelected() // draw raycast in editor 
    {
       if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Vector3 endPosition = transform.position + direction * detectionRadius;
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, endPosition);
        } 
    }
    
}
/* TODO: Catch the player if they are touched by the seeker
*/
using UnityEditor.Callbacks;
using UnityEngine;

public class SeekerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private bool playerDetected = false; // Flag to check if the player is detected
    [SerializeField] private bool shouldMove = false; // Angle within which the seeker can detect the player
    [SerializeField] private float detectionRadius = 5f; // Radius within which the seeker can detect the player
    [SerializeField] private GameObject player; // Radius within which the seeker can detect the player
    private Vector2 directionToPlayer;
    float distanceToPlayer; 
    private Rigidbody2D rb; 
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    void Start()
    {

    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        directionToPlayer = (player.transform.position - transform.position).normalized;

        TryDetectPlayer(); // updates player detected flag

        if (playerDetected && distanceToPlayer >= 1.5f)  // if the player is detected and within a certain distance (so it doesn't run into player)
        {
            MoveToPlayer();
        }

        Debug.DrawRay(transform.position, directionToPlayer * detectionRadius, Color.red); // draw a ray in the editor for debugging
        Debug.Log($"Distance to player: {distanceToPlayer}, Player Detected: {playerDetected}");
    }

    void MoveToPlayer() // move to player if the player has been 'seen' by the seeker
    {
        RotateEnemy(directionToPlayer); // rotate the enemy towards the player
        //transform.position += (Vector3)(directionToPlayer * moveSpeed * Time.deltaTime);
        rb.MovePosition(rb.position + (Vector2)(moveSpeed * Time.fixedDeltaTime * directionToPlayer));

    }

    void TryDetectPlayer() // try to detect the player by casting a ray in the direction of the player
    {
        playerDetected = false; // assume player is not detected at the start of each frame
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, directionToPlayer, detectionRadius); 

        foreach (var hit in hits)
        {
            if (hit.collider == null)
                continue;
                
            if (hit.collider.gameObject == this.gameObject) // bypass self
                continue;

            if (hit.collider.CompareTag("Player")) // first meaningful hit
            {
                playerDetected = true;
            }

            break; // exit the loop after first valid hit (even if its not player)
        }
    }

    void RotateEnemy(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    void OnDrawGizmosSelected() // draw raycast in editor 
    {
       if (player != null)
        {
            Vector2 endPosition = (Vector2)transform.position + directionToPlayer * detectionRadius;
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, endPosition);
        } 
    }
}
/* TODO: Catch the player if they are touched by the seeker
         - State machine for seeker 
         - search corutine for seeker
         - multiple raycast for detection at multiple angles
*/
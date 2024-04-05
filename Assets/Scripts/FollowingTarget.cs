using UnityEngine;

public class FollowingTarget : MonoBehaviour
{
    public Transform target; // Player character's transform
    public float moveSpeed = 3.0f; // Speed at which the NPC moves
    public float stoppingDistance = 5.0f; // Distance at which the NPC stops following

    private bool shouldFollow = true; // Flag to indicate whether NPC should follow
    private Animator anim; // Reference to the NPC's Animator component

    void Start()
    {
        anim = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        if (shouldFollow && target != null)
        {
            // Calculate the distance between NPC and player
            float distance = Vector3.Distance(transform.position, target.position);

            // Check if the distance is greater than the stopping distance
            if (distance > stoppingDistance)
            {
                // Move NPC towards the player
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

                // Play movement animation
                anim.SetBool("walk", true);

                // Rotate NPC to face the player
                transform.LookAt(target);

                Debug.Log("NPC is following the player.");
            }
            else
            {
                // Stop movement animation
                anim.SetBool("walk", false);
                Debug.Log("NPC stopped following the player. Reached stopping distance.");
            }
        }
        else
        {
            // Stop movement animation if player is null or shouldFollow is false
            anim.SetBool("walk", false);
            Debug.Log(target);
            Debug.Log("NPC stopped following the player. Player is null or shouldFollow is false.");
        }
    }

    // Method to start following the player
    public void StartFollowing()
    {
        shouldFollow = true;
        Debug.Log("NPC started following the player.");
    }

    // Method to stop following the player
    public void StopFollowing()
    {
        shouldFollow = false;
        Debug.Log("NPC stopped following the player.");
    }
}

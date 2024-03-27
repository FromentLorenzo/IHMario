using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class NewBehaviourScript  : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float turnSpeed = 200f;

    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true; // Freeze rotation to prevent unwanted physics interactions
    }

    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
        animator.SetFloat("Speed", Mathf.Abs(moveInput)); // Use Mathf.Abs to ensure positive speed value
    }

    void Rotate()
    {
        float turnInput = Input.GetAxis("Horizontal");
        float turn = turnInput * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}

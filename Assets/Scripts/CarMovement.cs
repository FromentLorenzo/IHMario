using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Rigidbody rg;
    public float forwardMoveSpeed;
    public float backwardMoveSpeed;
    public float steerSpeed;
    private Vector2 input;
    private bool isGrounded = true;
    private bool deployingParachute = false;

    public float raycastDistance = 1f;
    public LayerMask groundLayer;

    public GameObject parachute;

    public void SetInputs(Vector2 input)
    {
        this.input = input;
    }

    void Start()
    {
        if (parachute != null)
        {
            parachute.SetActive(false);
        }
    }

    void FixedUpdate() 
    {
        float moveSpeed = input.y > 0 ? forwardMoveSpeed : backwardMoveSpeed;
        moveSpeed *= Mathf.Abs(input.y); 

        rg.AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);

        float rotation = input.x * steerSpeed * Time.fixedDeltaTime;
        transform.Rotate(0, rotation, 0, Space.World);

        if (!isGrounded && !deployingParachute)
        {
            StartCoroutine(DeployParachuteAfterDelay());
        } else if (isGrounded && deployingParachute)
        {
            StartCoroutine(UnshowParachuteAfterDelay());
        }
    }

    private IEnumerator DeployParachuteAfterDelay()
    {
        deployingParachute = true;
        yield return new WaitForSeconds(0.3f);
        parachute.SetActive(true);
    }

    private IEnumerator UnshowParachuteAfterDelay()
    {
        deployingParachute = false;
        yield return new WaitForSeconds(0.2f);
        parachute.SetActive(false);
    }
     void Update()
    {
        print(isGrounded);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }

}

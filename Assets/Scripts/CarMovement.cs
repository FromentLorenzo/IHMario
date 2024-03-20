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

    public void SetInputs(Vector2 input) {  this.input = input; }

    void FixedUpdate() // Apply physics here
    {
        // Accelerate
        float moveSpeed = input.y > 0 ? forwardMoveSpeed : backwardMoveSpeed;
        moveSpeed *= Mathf.Abs(input.y); // This ensures that moveSpeed is zero if input.y is 0

        // Apply forward or backward force based on the input
        rg.AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);

        // Steer the car based on the horizontal input
        float rotation = input.x * steerSpeed * Time.fixedDeltaTime;
        transform.Rotate(0, rotation, 0, Space.World);
    }
}

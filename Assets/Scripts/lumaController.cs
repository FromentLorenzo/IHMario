using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lumaController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this speed as needed
    public float yOffset = 1f;
    private Vector3 initialPosition;
    private bool isMoving = false;
    private Transform target;

    void Start()
    {
        transform.LookAt(Camera.main.transform);
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            Move();
        }
    }

    public void MoveTowards(Transform newTarget)
    {
        target = newTarget;
        isMoving = true;
    }

    public void MoveToInitialPosition()
    {
        target = null;
        isMoving = true;
    }

    private void Move()
    {
        Vector3 targetPosition;
        if (target != null)
        {
            targetPosition = target.position + Vector3.up * yOffset; // Ajoutez le décalage vertical
        }
        else
        {
            targetPosition = initialPosition;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
        transform.LookAt(Camera.main.transform);
    }
}
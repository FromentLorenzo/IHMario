using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float turnSpeed = 200f;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = Vector3.forward  * Input.GetAxis("Vertical") * speed;
        transform.Translate(velocity * Time.deltaTime);
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal")* Time.deltaTime*turnSpeed);
        animator.SetFloat("Speed", velocity.magnitude);
    }
}

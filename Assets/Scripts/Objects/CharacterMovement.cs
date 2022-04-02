using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    public float speed, runningSpeed;
    public bool isRunning;

    protected Rigidbody rb;
    protected Animator anim;

    
    public Vector3 direction { get; set; }


    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    protected void Update()
    {
        anim.SetBool("walk", direction.magnitude > 0.01f);
    }

    protected private void FixedUpdate()
    {
        var velocity = direction * (isRunning ? runningSpeed : speed); 
        rb.velocity = CommonTools.yPlaneVector(velocity, rb.velocity.y);
    }
}

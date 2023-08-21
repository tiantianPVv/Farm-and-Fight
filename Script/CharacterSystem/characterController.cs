using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{

    Animator amimator;
    Rigidbody2D rb;

    [SerializeField] int WalkSpeed;

    private Vector2 motionVector;
    private Vector2 lastMotionVector;

    private void Awake()
    {
        amimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        lastMotionVector = new Vector2(0, -1);
    }


    void Update()
    {
        motionVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (motionVector.x==0 && motionVector.y==0)
        {
            amimator.SetBool("Moving", false);
            amimator.SetFloat("LastVelocityX",lastMotionVector.x);
            amimator.SetFloat("LastVelocityY", lastMotionVector.y);
            

        }
        else
        {
           
            lastMotionVector = motionVector;
            amimator.SetBool("Moving", true);
            amimator.SetFloat("VelocityX", motionVector.x);
            amimator.SetFloat("VelocityY", motionVector.y);
        }
        

    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = motionVector * WalkSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAnimation : MonoBehaviour
{
    //Animator fields
    private Animator animator;
    private Rigidbody rb;
    private float maxSpeed = 5f;

    //saves the information form the Anmiator and the Rigidbody to there variables
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }    
    //Gives (sets) the Animator the absulut speed of the Rigidbody 
    void Update()
    {
        animator.SetFloat("speed", rb.velocity.magnitude / maxSpeed);
    }
}
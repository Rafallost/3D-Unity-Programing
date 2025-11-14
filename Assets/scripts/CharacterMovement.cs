using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float accel = 400.0f;
    public float maxSpeed = 2.0f;
    public float rotateSpeed = 2.0f;

    private Vector3 moveDirection = Vector3.zero;
    public Animator anim;

    // Update is called once per physics frame
    void FixedUpdate()
    {
        bool checkSprint = Input.GetKey(KeyCode.LeftShift);

        // Move forward/backward
        moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= (checkSprint) ? accel * 5 : accel;

        rb.AddForce(moveDirection * Time.deltaTime);

        // Rotate player
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Limit max speed
        Vector3 vel = rb.linearVelocity;
        float maxSpeedLocal = (checkSprint) ? maxSpeed * 5 : maxSpeed;
        if (vel.magnitude > maxSpeedLocal)
        {
            rb.linearVelocity = vel.normalized * maxSpeedLocal;
        }

        // Animation control
        if (vel.magnitude > 0.0f)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);


        anim.SetBool("isRuning", checkSprint);

        
    }
}

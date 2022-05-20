using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    float h;
    float v;
    Rigidbody rb;

    [Header("Movement")]
    public float speed;
    public float turnSpeed;

    [Header("Sound")]
    public AudioSource idleSound;
    public AudioSource movementSound;
    public bool movementIsPlay;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementIsPlay = false;
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        Move();
        Turn();
        if(v != 0 && movementIsPlay == false)
        {
            movementIsPlay = true;
            movementSound.Play();
            idleSound.Stop();
        }
        else if (v == 0 && movementIsPlay == true)
        {
            movementIsPlay = false;
            idleSound.Play();
            movementSound.Stop();
        }
    }

    void Move()
    {
        Vector3 movement = transform.forward * v * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        
    }

    void Turn()
    {
        float turn = h * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}

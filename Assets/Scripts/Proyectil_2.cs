using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil_2 : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    Vector3 vProyectile;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vProyectile = transform.forward + transform.up;
        rb.AddForce(vProyectile * speed);
        Destroy(gameObject, 5);
    }

}

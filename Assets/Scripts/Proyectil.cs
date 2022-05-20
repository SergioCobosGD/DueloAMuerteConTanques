using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float speed;
    private void Start()
    {
        Destroy(gameObject, 5);
    }
    void Update()
    {
        transform.Translate(speed * Vector3.forward * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirBalas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("EnemyProyectile"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Proyectile"))
        {
            Destroy(other.gameObject);
        }
    }
}

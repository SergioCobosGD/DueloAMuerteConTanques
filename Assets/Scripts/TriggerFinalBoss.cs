using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFinalBoss : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Final")
        {
            SceneManager.LoadScene("MainGameBoss");
        }
    }
}

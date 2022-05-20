using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretMovement : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public LayerMask layerFloor;

    Vector3 direction;
    public GameObject enemyTarget;
    public GameObject oldEnemyTarget;
    Enemy enemyScript;
    Enemy oldEnemyScript;

    //Detector de vida enemigo por canvas
    public GameObject enemyBarCanvasGameObject;
    public Image enemyBarCanvas;
    EnemyHealth enemyHealth;

    public bool tarjet;
    private void Start()
    {
        tarjet = false;
    }
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(tarjet == false)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerFloor))
            {
                Vector3 point = hit.point;
                direction = hit.point - transform.position;
                //Con direction.y igual a 0 te evitas que el personaje gire en ese eje
                direction.y = 0;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = rotation;
            }
        }
        else if (tarjet == true)
        {
            if (enemyTarget == null)
            {
                tarjet = false;
                return;
            }
            direction = enemyTarget.transform.position - transform.position;
            direction.y = 0;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.transform.tag == "Enemy")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    tarjet = true;
                    enemyTarget = hit.transform.gameObject;
                    enemyScript = enemyTarget.GetComponent<Enemy>();
                    enemyScript.target.SetActive(true);
                    enemyHealth = enemyTarget.GetComponent<EnemyHealth>();
                    if (oldEnemyTarget != enemyTarget && oldEnemyTarget != null)
                    {
                        oldEnemyScript = oldEnemyTarget.GetComponent<Enemy>();
                        oldEnemyScript.target.SetActive(false);
                    }
                    oldEnemyTarget = enemyTarget;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            tarjet = false;
            enemyScript.target.SetActive(false);
        }
        //Coge la vida del target enemigo y la pone por pantalla
        if (tarjet == true)
        {
            enemyBarCanvasGameObject.SetActive(true);
            enemyBarCanvas.fillAmount = enemyHealth.healthBar.fillAmount;
        }
        else
        {
            enemyBarCanvasGameObject.SetActive(false);
        }
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
    }
}

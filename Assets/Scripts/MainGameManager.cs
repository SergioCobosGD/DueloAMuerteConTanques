using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    GameManager gameManager;
    //Los admin acabados en _0 son los que bloquean el camino, los _1 son los de nivel completado
    public GameObject Admin_1_0;
    public GameObject Admin_1_1;
    public GameObject Admin_2_0;
    public GameObject Admin_2_1;
    public GameObject Admin_3_0;
    public GameObject Admin_3_1;
    public GameObject enemyTank1;
    public GameObject Admin_3_2;
    public GameObject Admin_4_0;
    public GameObject Admin_4_1;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.enemyDefeat == 1)
        {
            Admin_1_0.SetActive(false);
            Admin_1_1.SetActive(true);
        }
        else if(gameManager.enemyDefeat == 2)
        {
            Admin_2_0.SetActive(false);
            Admin_2_1.SetActive(true);
        }
        else if (gameManager.enemyDefeat == 4)
        {
            Admin_3_0.SetActive(false);
            Admin_3_1.SetActive(true);
            enemyTank1.SetActive(true);
        }
        else if (gameManager.enemyDefeat == 5)
        {
            Admin_3_1.SetActive(false);
            Admin_3_2.SetActive(true);
            Admin_4_0.SetActive(true);
        }
        else if (gameManager.enemyDefeat == 6)
        {
            Admin_4_0.SetActive(false);
            Admin_4_1.SetActive(true);
        }

    }
}

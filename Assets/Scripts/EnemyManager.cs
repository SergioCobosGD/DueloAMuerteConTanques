using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] posRotEnemy; //array con las posiciones de salida del enemigo
    public float timeBetweenEnemies;

    public Transform parentEnemies; //Este gameObject va a tener como hijo a los clones de los enemigos
    public int maxEnemiesOnLevel; //Nº máximo de enemigos que va a haber en la escena
    void Start()
    {
        InvokeRepeating("CreateEnemy", timeBetweenEnemies, timeBetweenEnemies);
    }

    void CreateEnemy()
    {
        int numEnemies = parentEnemies.childCount;

        if (numEnemies >= maxEnemiesOnLevel) return; //Si el numero de enemigos es ,mayor que el numero maximo de enemigos permitedos, tira un return, que hace que salga de la funcion

        int n = Random.Range(0, posRotEnemy.Length);
        GameObject cloneEnemy = Instantiate(enemyPrefab, posRotEnemy[n].position, posRotEnemy[n].rotation);
        //cada vez que creo un clone del prefab, lo pongo como hijo del gameobject parentEnemies
        cloneEnemy.transform.SetParent(parentEnemies);
    }
}

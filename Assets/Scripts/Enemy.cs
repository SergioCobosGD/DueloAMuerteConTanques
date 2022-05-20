using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent agent;
    [Header("Attack")]
    public GameObject bullet;
    public GameObject proyectile;
    public Transform pos;
    public float bulletTime;
    public float proyectileTime;
    public float bulletCoolDown;
    public float proyectileCoolDown;
    GameManager gameManager;

    AudioSource bulletSound;

    public GameObject target;

    //Raycast
    Ray ray;
    RaycastHit hit;
    public Transform trans;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        bulletSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - trans.position;
        ray = new Ray(trans.position, direction);
        if(Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.transform.tag);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            if (hit.transform.tag == "Player")
            {
                agent.SetDestination(player.transform.position);
                transform.LookAt(player.transform);
                if (bulletTime < 8)
                {
                    bulletTime += Time.deltaTime;
                }
                if (proyectileTime < 8)
                {
                    proyectileTime += Time.deltaTime;
                }

                if (bulletTime > bulletCoolDown)
                {
                    InstantiateBullet();
                    bulletSound.Play();
                    bulletTime = 0;
                }
                if (proyectileTime > proyectileCoolDown)
                {
                    InstantiateProyectile();
                    bulletSound.Play();
                    proyectileTime = 0;
                }
            }
        }
    }
    void InstantiateBullet()
    {
        GameObject cloneProyectil = Instantiate(bullet, pos.transform.position, pos.transform.rotation);
        //bulletSound.Play();
    }
    void InstantiateProyectile()
    {
        GameObject cloneProyectil = Instantiate(proyectile, pos.transform.position, pos.transform.rotation);
        //bulletSound.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankAttack : MonoBehaviour
{
    [Header("Attack")]
    public GameObject bullet;
    public GameObject proyectile;
    public Transform pos;
    public float bulletTime;
    public float proyectileTime;
    public float bulletCoolDown;
    public float proyectileCoolDown;

    AudioSource bulletSound;

    [Header("UI")]
    public Image bulletBar;
    public Image proyectileBar;

    private void Start()
    {
        bulletBar.fillAmount = 1;
        proyectileBar.fillAmount = 1;
        bulletSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletBar.fillAmount = bulletTime / bulletCoolDown;
        proyectileBar.fillAmount = proyectileTime / proyectileCoolDown;

        if(bulletTime < bulletCoolDown)
        {
            bulletTime += Time.deltaTime;
        }
        if(proyectileTime < proyectileCoolDown)
        {
            proyectileTime += Time.deltaTime;
        }

        if(bulletTime > bulletCoolDown)
        {
            if (Input.GetMouseButtonDown(0))
            {
                InstantiateBullet();
                bulletTime = 0;
                bulletSound.Play();
            }
        }
        if (proyectileTime > proyectileCoolDown)
        {
            if (Input.GetMouseButtonDown(1))
            {
                InstantiateProyectile();
                proyectileTime = 0;
                bulletSound.Play();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("UI")]
    public Image healthBar;
    public float totalHealth;
    public float currentHealth;
    public float bulletDamage;
    public float proyectileDamage;
    GameManager gameManager;
    public ParticleSystem explosion;
    AudioSource bulletSound;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        currentHealth = totalHealth;
        healthBar.fillAmount = 1;
        bulletSound = GetComponent<AudioSource>();
        //enemyBarCantidad = GameObject.FindGameObjectWithTag("EnemyHealthCantidad").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = currentHealth / totalHealth;
        if(currentHealth <= 0)
        {
            gameManager.enemyDefeat++;
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            //enemyBarCantidad.fillAmount = currentHealth / totalHealth;
            currentHealth -= bulletDamage;
            explosion.Play();
            bulletSound.Play();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Proyectile"))
        {
            //enemyBarCantidad.fillAmount = currentHealth / totalHealth;
            currentHealth -= proyectileDamage;
            explosion.Play();
            bulletSound.Play();
            Destroy(other.gameObject);
        }
    }
}

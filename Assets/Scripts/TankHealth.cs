using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    [Header("UI")]
    public Image healthBar;
    public float totalHealth;
    public float currentHealth;
    public float bulletDamage;
    public float proyectileDamage;
    public GameObject panelGameOver;
    public ParticleSystem explosion;
    AudioSource bulletSound;
    void Start()
    {
        currentHealth = totalHealth;
        healthBar.fillAmount = 1;
        bulletSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = currentHealth / totalHealth;
        if(currentHealth <= 0)
        {
            GameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            currentHealth -= bulletDamage;
            explosion.Play();
            bulletSound.Play();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("EnemyProyectile"))
        {
            currentHealth -= proyectileDamage;
            explosion.Play();
            bulletSound.Play();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Cura"))
        {
            currentHealth = totalHealth;
            Destroy(other.gameObject);
        }
    }
    void GameOver()
    {
        panelGameOver.SetActive(true);
        Time.timeScale = 0f;
    }
}

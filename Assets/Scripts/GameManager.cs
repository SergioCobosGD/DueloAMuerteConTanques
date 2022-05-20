using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI enemyCount;
    public GameObject youWin;
    public float enemyDefeat;
    public float enemyToWin = 10;
    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Update()
    {
        enemyCount.text = "Enemigos derrotados = " + enemyDefeat;
        if(enemyDefeat >= enemyToWin)
        {
            YouWin();
        }
    }
    public void LoadLevelScene()
    {
        SceneManager.LoadScene("Level");
    }
    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void LoadMainGameBoss()
    {
        SceneManager.LoadScene("MainGameBoss");
    }
    public void YouWin()
    {
        youWin.SetActive(true);
        Time.timeScale = 0f;
    }
}

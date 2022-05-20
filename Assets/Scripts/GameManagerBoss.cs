using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerBoss : MonoBehaviour
{
    public GameObject youWin;
    public GameObject Mikey;
    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (Mikey == null)
        {
            YouWin();
        }
    }
    public void LoadLevelScene()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void YouWin()
    {
        youWin.SetActive(true);
        Time.timeScale = 0f;
    }
}

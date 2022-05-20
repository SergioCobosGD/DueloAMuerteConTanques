using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void LoadLevelScene()
    {
        SceneManager.LoadScene("Level");
    }
    public void LoadMainGameScene()
    {
        SceneManager.LoadScene("MainGame");
    }
}

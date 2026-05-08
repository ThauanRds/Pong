using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayWithIA()
    {
        SceneManager.LoadScene("Player_VS_IA");
    }

    public void PlayWithPlayer()
    {
        SceneManager.LoadScene("Player_VS_Player");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

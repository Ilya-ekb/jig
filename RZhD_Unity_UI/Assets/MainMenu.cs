using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SettingsGame()
    {
        SceneManager.LoadScene("SettingsMainMenu");
    }
    public void ExitGame()
    {
        Debug.Log("Игра закончилась!");
        Application.Quit();
    }
}

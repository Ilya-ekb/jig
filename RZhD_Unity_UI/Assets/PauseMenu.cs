using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void BackToTheGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SaveGame()
    {
        SceneManager.LoadScene("SavingScene");
    }
    
    public void SettingsGame()
    {
        SceneManager.LoadScene("SettingsPauseMenu");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public void WinGame()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void DefeatGame()
    {
        SceneManager.LoadScene("DefeatScene");
    }
}
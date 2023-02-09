using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavingScene : MonoBehaviour
{
    public void SavingGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}

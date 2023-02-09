using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoading : MonoBehaviour
{
    public void LoadingGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}

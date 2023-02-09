using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBackground : MonoBehaviour
{
    public void StopGame()
    {
        SceneManager.LoadScene("PauseMenu");
    }
}

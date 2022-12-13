using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EntryPoint : MonoBehaviour
{
    public static EntryPoint Instance;

    public event Action OnModelInit;
    public event Action OnControlInit;
    public event Action OnViewInit;

    private void Awake () {
        Instance = this;
    }

    void Start()
    {
        var scene = SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().name);
        scene.completed += LoadingCompleted;
    }

    private void LoadingCompleted (AsyncOperation asynk) {
        OnModelInit?.Invoke ();
        OnControlInit?.Invoke ();
        OnViewInit?.Invoke ();
    }
}
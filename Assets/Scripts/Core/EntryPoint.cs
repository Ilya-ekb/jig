using UnityEngine;
using UnityEngine.Events;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private UnityEvent ApplicationEntry;

    void Start()
    {
        ApplicationEntry.Invoke();
    }
}

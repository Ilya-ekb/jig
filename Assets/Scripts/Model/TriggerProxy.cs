using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class ColliderEvent : UnityEvent<Collider>
{
}

public class TriggerProxy : MonoBehaviour
{
    public ColliderEvent TriggerEntered;
    public ColliderEvent TriggerExited;

    void Start()
    {
        if (TriggerEntered == null)
            TriggerEntered = new ColliderEvent();
        if (TriggerExited == null)
            TriggerExited = new ColliderEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerEntered.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerExited.Invoke(other);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        collider.gameObject.GetComponent<PoolObject>().ReturnToPool();
    }
}

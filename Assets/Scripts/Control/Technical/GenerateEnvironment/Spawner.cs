using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObject;
    public float scaleSpawn;

    public Transform mover;

    public bool spawn;

    public float maxTimeInterval;
    public float minTimeInterval;

    public float probability;

    private float _waitTime;
    void Start()
    {
        spawn = true;
        _waitTime = 0;

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(_waitTime);

            if (probability > Random.value)
            {
                GameObject gameObject;
                Vector3 generatePosition = mover.position + (transform.position- mover.position);

                //Instantiate(spawnObject, generatePosition, transform.rotation, mover).transform.localScale *= scaleSpawn;
                gameObject = PoolManager.GetObject(spawnObject.name, generatePosition, transform.rotation, Vector3.one*scaleSpawn);
            }

            _waitTime = maxTimeInterval * Random.RandomRange(minTimeInterval, maxTimeInterval);
        }
    }
}

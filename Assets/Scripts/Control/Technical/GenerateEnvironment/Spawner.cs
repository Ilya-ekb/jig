using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObject;
    public Transform mover;

    public bool spawn;

    public float maxTimeInterval;
    public float minTimeInterval;

    public float probability;

    private Vector3 startPosition;

    private float waitTime;
    void Start()
    {
        startPosition = transform.position;

        spawn = true;
        waitTime = 0;

        StartCoroutine(TestCoroutine());
    }

    IEnumerator TestCoroutine()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(waitTime);

            if (probability > Random.value)
            {
                Vector3 generatePosition = mover.position + (transform.position- mover.position);

                Instantiate(spawnObject, generatePosition, transform.rotation, mover);
            }

            waitTime = maxTimeInterval * Random.RandomRange(minTimeInterval, maxTimeInterval);
        }
    }
}

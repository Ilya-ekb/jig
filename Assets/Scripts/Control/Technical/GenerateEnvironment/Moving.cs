using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed = -2f;
    
    void Update()
    {
        Vector3 input = new Vector3(0,0,1);
        transform.position = transform.position + input * Time.deltaTime * speed;
    }
}

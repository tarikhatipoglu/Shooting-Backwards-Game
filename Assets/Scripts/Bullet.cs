using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        MoveBullet(-25f);
        Destroy(gameObject, 3f);
    }

    void MoveBullet(float A)
    {
        transform.position += new Vector3(0, 0, A * Time.deltaTime);
    }
}

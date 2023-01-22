using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeMover : MonoBehaviour
{    
    Vector3 LocalSpace;
    public bool isRight;
    private Walking _walking;
    public float speed;

    void Start()
    {
        _walking = FindObjectOfType<Walking>();
        if (isRight)
        {
            LocalSpace = transform.TransformDirection(Vector3.right);
        }
        else
        {
            LocalSpace = transform.TransformDirection(Vector3.left);

        }
    
    }

    void Update()
    {
        transform.position +=  (Time.deltaTime * LocalSpace* speed * _walking.speed);
    }
}

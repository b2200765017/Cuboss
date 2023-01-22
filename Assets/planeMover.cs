using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeMover : MonoBehaviour
{
    Vector3 LocalSpace;
    public bool isRight;
    private Walking _walking;
    public UIManager _UIManager;
    
    public Vector3 targetPosition;
    public float speed = 0.1f;

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
        if (_UIManager.timeLeft <= 0) Destroy(this);
        transform.position +=  (Time.deltaTime * LocalSpace* speed * _walking.speed);
    }
}

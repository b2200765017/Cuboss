using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bestScore : MonoBehaviour
{
    // Start is called before the first frame update
    public int scorePosition;
    [SerializeField] private Walking _walking;
    private Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        scorePosition = PlayerPrefs.GetInt("score");
        if (scorePosition < 10) return;
        transform.position = new Vector3(-scorePosition, 1, scorePosition);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_walking._points >= (scorePosition+3)) _rigidbody.AddForce(100,100,100);

    }
}

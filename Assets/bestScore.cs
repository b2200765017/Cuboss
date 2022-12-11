using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bestScore : MonoBehaviour
{
    // Start is called before the first frame update
    public int scorePosition;
    [SerializeField] private Walking _walking;
    void Start()
    {
        scorePosition = PlayerPrefs.GetInt("score");
        if (scorePosition < 10) return;
        transform.position = new Vector3(-scorePosition, 0, scorePosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (_walking._dead)
        {
            
        }
    }
}

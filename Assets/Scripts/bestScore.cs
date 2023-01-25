using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bestScore : MonoBehaviour
{
    public int scorePosition;
    void Start()
    {
        scorePosition = PlayerPrefs.GetInt("score");
        if (scorePosition < 10) return;
        transform.position = new Vector3(-scorePosition, 0, scorePosition);
    }
    
}

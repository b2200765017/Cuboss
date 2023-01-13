using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public int is_activated = 0;
    private bool isButtonHeld = false;
    private float timeHeld;
    private bool onSlowMo = false;
    private Walking _walking;

    private void Start()
    {
        _walking = GetComponent<Walking>();
    }

    void Update()
    {
        if (is_activated != 0)
        {
            if (Input.GetButtonDown("Fire1")) {
                    isButtonHeld = true;
            }
            if (Input.GetButtonUp("Fire1")) {
                isButtonHeld = false;
                timeHeld = 0;
                if (onSlowMo)
                {
                    onSlowMo = false;
                    StartCoroutine(timeback());
                    _walking.is_left = !_walking.is_left;
                    //_walking.RotationAnimation();
                    _walking.Rotating();
                    is_activated--;
                }
                
                
            }
            if (isButtonHeld) {
                timeHeld += Time.deltaTime;
            }

            if (timeHeld >= 0.22f)
            {
                Time.timeScale = 0.4f;
                onSlowMo = true;
            }
        }
    }
    IEnumerator timeback()
    {
        while (Time.timeScale <= 1)
        {
            Time.timeScale += 0.05f;
            yield return new WaitForSeconds(0.001f);
        }
    }
    
}


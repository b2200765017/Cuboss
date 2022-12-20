using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public bool is_activated = false;
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
        if (is_activated)
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
                    Time.timeScale = 1;
                    is_activated = false;
                    _walking.is_left = !_walking.is_left;
                    _walking.Rotating();
                }
                
                
            }
            if (isButtonHeld) {
                timeHeld += Time.deltaTime;
            }

            if (timeHeld >= 0.15f)
            {
                Time.timeScale = 0.3f;
                onSlowMo = true;
            }
        }
    }
    
}

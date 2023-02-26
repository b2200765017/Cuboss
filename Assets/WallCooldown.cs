using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCooldown : MonoBehaviour
{
    public bool isHit = false;

    private void OnDisable()
    {
        isHit = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbScript : MonoBehaviour
{
    public bool istouched = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
        istouched = true;
        other.GetComponent<Walking>().heart += 1;
        }
    }
}

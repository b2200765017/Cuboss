using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbScript : MonoBehaviour
{
    public bool istouched = false;
    [SerializeField] private ParticleSystem system;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
        istouched = true; 
        system.Play();
        }
    }
}

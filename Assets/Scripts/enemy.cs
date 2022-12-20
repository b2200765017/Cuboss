using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GetComponent<Animator>().SetTrigger("jump");
            other.transform.GetComponent<DeadManager>().dead = true;
        }
    }
}

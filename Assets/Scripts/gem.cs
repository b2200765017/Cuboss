using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gem : MonoBehaviour
{
    //private Animator animator;
    private Walking _walking;
    public int worth;
    private bool taken = false;
    private void Start()
    {
        _walking = FindObjectOfType<Walking>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            //animator = transform.GetComponent<Animator>();
            //animator.SetTrigger("collect");
            _walking._coins+=worth;
            _walking.sounds.PlayXpCollection();
            taken = true;
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if(taken)gameObject.SetActive(true);
        taken = false;
        
    }
    
}

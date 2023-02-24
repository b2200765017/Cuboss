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
            _walking.coins+=worth;
            if (_walking.sounds == null) _walking.sounds = FindObjectOfType<SoundManager>();
            _walking.sounds.PlayXpCollection();
            gameObject.SetActive(false);
            taken = true;
        }
    }

    
}

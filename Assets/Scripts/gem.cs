using System;
using UnityEngine;

public class gem : MonoBehaviour
{
    //private Animator animator;
    private Walking _walking;
    public int worth;
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
            _walking.sounds.gem_collected();
            gameObject.SetActive(false);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class orbScript : MonoBehaviour
{
    public bool istouched = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
        istouched = true;
        int pieces= other.GetComponent<Walking>().heartp;
        int heart= other.GetComponent<Walking>().heart;
        if (heart != 3)
        {
            if (pieces == 2)
            {
                other.GetComponent<Walking>().heart += 1;
                other.GetComponent<Walking>().heartp = 0;
            }
            else
            {
                other.GetComponent<Walking>().heartp += 1;
            }
        }
            
        }
        Destroy(gameObject);
    }
}

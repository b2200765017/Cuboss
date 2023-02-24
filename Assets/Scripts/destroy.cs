using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    [SerializeField] private int time;

    void Update()
    {
        Destroy(this.gameObject,time);
    }
}

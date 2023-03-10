using System;
using System.Collections;
using UnityEngine;
public class destroy : MonoBehaviour {
    
    [SerializeField] private int time;
    [SerializeField] private float Delaytime;
    [SerializeField] private GameObject[] footprints;
    private WaitForSeconds delay;

    private void Start()
    {
        delay = new WaitForSeconds(Delaytime);
        StartCoroutine(footprintFunction());
    }

    void Update() {
        Destroy(gameObject, time);
    }

    IEnumerator footprintFunction()
    {
        for (int i = 0; i < footprints.Length; i++)
        {
            footprints[i].SetActive(true);
            SoundManager.instance.PlayFootsteps();
            yield return delay;
        }
    }
}


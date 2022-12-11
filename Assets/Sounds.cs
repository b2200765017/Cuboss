using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip gem;
    public AudioClip step;
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("music");
        if (gameObjects.Length != 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void gem_collected()
    {
        audioSource.PlayOneShot(gem);
    }
    public void step_()
    {
        audioSource.PlayOneShot(step);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDublicates : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("mainmusic");
        if (gameObjects.Length != 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

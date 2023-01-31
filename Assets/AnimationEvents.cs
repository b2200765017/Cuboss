using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public  List<GameObject> footprints;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void footPrint()
    {
        footprints[index].SetActive(true);
        index++;
    }
}

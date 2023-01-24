using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Patterns
{
    public GameObject _patternname;
}

public class World_Manager : MonoBehaviour
{
    [SerializeField] public List<Patterns> _patternsList;
    public float offset = 0f;

    
    private float initial_x = -6f;
    private float initial_z = 6f;

    public void prefabPattern(Patterns pattern)
    {
        GameObject gameObject = Instantiate(pattern._patternname);
        gameObject.transform.position = new Vector3(initial_x + (offset * -2), 0f, initial_z + (offset * +2));
        transform.rotation = Quaternion.identity;
        offset += 19.75f / 2;
        
    }
}

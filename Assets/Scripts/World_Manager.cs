using System;
using System.Collections.Generic;
using UnityEngine;


public class World_Manager : MonoBehaviour
{
    [SerializeField] public List<String> _patternsList;
    public float offset = 0f;

    
    [SerializeField] private ObjectPooler _objectPooler;
    private float initial_x = -6f;
    private float initial_z = 6f;

    public void prefabPattern(String pattern)
    {
        _objectPooler.SpawnFromPool(pattern,
            new Vector3(initial_x + (offset * -2), 0f, initial_z + (offset * +2)), Quaternion.identity);
        offset += 19.79899f / 2;
        
    }
}

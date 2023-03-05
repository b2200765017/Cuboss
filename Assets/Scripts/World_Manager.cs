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
    private Vector3 positionVector;

    public void prefabPattern(String pattern)
    {
        positionVector.x = initial_x + (offset * -2);
        positionVector.y = 0f;
        positionVector.z = initial_z + (offset * +2);
        _objectPooler.SpawnFromPool(pattern, positionVector, Quaternion.identity);
        offset += 19.79899f / 2;
    }
}

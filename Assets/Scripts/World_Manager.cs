using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct Patterns
{
    public string _patternname;
    public int dificulty;
    public int offset;
}

public class World_Manager : MonoBehaviour
{
    [SerializeField] public List<Patterns> _patternsList;
    private ObjectPooler _objectPooler;
    [SerializeField] private int number_of_platform = 5;
    [SerializeField] private float Chance_of_gem = 0.04f;
    private WaitForSeconds delay;
    public bool _isstarting = false;
    
    private float initial_x = 2f;
    private float initial_z = -2f;
    public float offset = 0;
    public Vector3 groundPosition;
    

    private float height = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        offset += 5;
        groundPosition = new Vector3(8, 0, -8);
        _objectPooler = GameObject.FindObjectOfType<ObjectPooler>();
        delay = new WaitForSeconds(0.17f);
        //StartCoroutine(StartAnimation());
    }

    // Update is called once per frame

    public void PatternBuilder()
    {
        _objectPooler.SpawnFromPool("ground",
            groundPosition, Quaternion.identity);
        
        groundPosition -= new Vector3(8.485282f,0, -8.485282f);
    }

    public void prefabPattern(Patterns pattern)
    {
        _objectPooler.SpawnFromPool(pattern._patternname,
            new Vector3(initial_x + (offset * -2), height, initial_z + (offset * +2)), Quaternion.identity);
        offset += pattern.offset + 5;
        
    }

    IEnumerator StartAnimation()
    {
        _isstarting = true;
        for (int i = 0; i < 5; i++)
        {
            PatternBuilder();
            yield return delay;
        }
        int index = Random.Range(0, _patternsList.Count);
        Patterns pattern = _patternsList[index];
        prefabPattern(pattern);
        
        int indexs = Random.Range(3, 7);
        for (int i = 0; i < indexs; i++)
        {
            PatternBuilder();
            yield return delay;
        }
        _isstarting = false;
    }
}

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
    private string basic_ground = "ground";
    private string gem_ground = "gemground";
    private string enemy_ground = "enemyground";
    [SerializeField] private int number_of_platform = 5;
    [SerializeField] private float Chance_of_gem = 0.04f;
    private WaitForSeconds delay;
    public bool _isstarting = false;
    
    private float initial_x = 2f;
    private float initial_z = -2f;
    public float offset = 0;

    private float height = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        _objectPooler = GameObject.FindObjectOfType<ObjectPooler>();
        delay = new WaitForSeconds(0.17f);
        StartCoroutine(StartAnimation());
    }

    // Update is called once per frame

    public void PatternBuilder()
    {
         Stack<string> patternToBuild = new Stack<string>();
        for (int i = 0; i < (number_of_platform * 2) + 1; i++)
        {
            if (Random.value  > Chance_of_gem) patternToBuild.Push(basic_ground);
            else patternToBuild.Push(gem_ground);
        }
        Vector3 transform_of_ground = new Vector3(initial_x + (offset * -2), height, initial_z + (offset * +2));
        _objectPooler.SpawnFromPool(patternToBuild.Pop(), transform_of_ground, Quaternion.identity);
        for (int i = 1; i < number_of_platform; i++)
        {
            Vector3 transform_of_ground_left = new Vector3(initial_x + (offset * -2) + (i * -2), height, initial_z + (offset * +2));
            Vector3 transform_of_ground_right = new Vector3(initial_x + (offset * -2), height, initial_z + (offset * +2)+ (i * 2));
            _objectPooler.SpawnFromPool(patternToBuild.Pop() , transform_of_ground_right, Quaternion.identity);
            _objectPooler.SpawnFromPool(patternToBuild.Pop(), transform_of_ground_left, Quaternion.identity);
        }
        offset++;
    }

    public void prefabPattern(Patterns pattern)
    {
        _objectPooler.SpawnFromPool(pattern._patternname,
            new Vector3(initial_x + (offset * -2), height, initial_z + (offset * +2)), Quaternion.identity);
        offset += pattern.offset;

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
        for (int i = 0; i < 10; i++)
        {
            PatternBuilder();
            yield return delay;
        }
        _isstarting = false;
    }
}

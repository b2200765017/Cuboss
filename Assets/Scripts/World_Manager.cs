using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_Manager : MonoBehaviour
{
    private ObjectPooler _objectPooler;
    [SerializeField] private GameObject ground;
    [SerializeField] private int number_of_platform = 5;
    private WaitForSeconds delay;
    
    private float initial_x = 2f;
    private float initial_z = -2f;
    private float offset = 0;

    private float height = 0.03f;
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
        Vector3 transform_of_ground = new Vector3(initial_x + (offset * -2), height, initial_z + (offset * +2));
        _objectPooler.SpawnFromPool("ground", transform_of_ground, Quaternion.identity);
        for (int i = 1; i < number_of_platform; i++)
        {
            Vector3 transform_of_ground_left = new Vector3(initial_x + (offset * -2) + (i * -2), height, initial_z + (offset * +2));
            Vector3 transform_of_ground_right = new Vector3(initial_x + (offset * -2), height, initial_z + (offset * +2)+ (i * 2));
            _objectPooler.SpawnFromPool("ground", transform_of_ground_right, Quaternion.identity);
            _objectPooler.SpawnFromPool("ground", transform_of_ground_left, Quaternion.identity);
        }
        offset++;
    }

    IEnumerator StartAnimation()
    {
        for (int i = 0; i < 20; i++)
        {
            PatternBuilder();
            yield return delay;
        }
    }
}

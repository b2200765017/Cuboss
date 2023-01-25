using UnityEngine;

public class enemy : MonoBehaviour
{
    private DeadManager _deadManager;

    private void Awake()
    {
        _deadManager = FindObjectOfType<DeadManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
           _deadManager.dead = true;
        }
    }
}

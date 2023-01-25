using UnityEngine;

public class DeathCollider : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}

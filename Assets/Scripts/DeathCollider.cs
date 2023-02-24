using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GemFixer fixer;
        if (other.TryGetComponent<GemFixer>(out fixer))
        {
            fixer.Fixer();
        }
        other.gameObject.SetActive(false);
    }
}

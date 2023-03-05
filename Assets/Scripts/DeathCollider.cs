using UnityEngine;
public class DeathCollider : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        GemFixer fixer;
        if (other.TryGetComponent(out fixer)) {
            fixer.Fixer();
        }
        other.gameObject.SetActive(false);
    }
}

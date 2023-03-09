using UnityEngine;
public class DeathCollider : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        GemFixer fixer;
        if (other.TryGetComponent(out fixer)) {
            fixer.Fixer();
        }
        Debug.Log("deleted");
        other.gameObject.SetActive(false);
    }
}

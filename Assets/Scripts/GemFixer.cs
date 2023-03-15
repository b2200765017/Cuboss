using UnityEngine;

public class GemFixer : MonoBehaviour {

    public void Fixer() {
        foreach (Transform transform in transform) {
            if (transform.CompareTag("gembox"))
            {
                if (TryGetComponent(out Animator animator))
                {
                    animator.enabled = false;
                }
            }
        }
    }
}

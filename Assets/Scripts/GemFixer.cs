using UnityEngine;

public class GemFixer : MonoBehaviour {

    public void Fixer() {
        foreach (Transform transform in transform) {
            if (transform.CompareTag("gembox"))
            {
                transform.GetComponentInChildren<Animator>().enabled = false;
            }
        }
    }
}

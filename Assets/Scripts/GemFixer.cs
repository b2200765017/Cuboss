using UnityEngine;

public class GemFixer : MonoBehaviour {

    public void Fixer() {
        foreach (Transform transform in transform) {
            if (transform.CompareTag("gembox"))
            {
                transform.GetComponent<Animator>().enabled = false;
            }
        }
    }
}

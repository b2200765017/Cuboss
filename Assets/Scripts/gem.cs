using UnityEngine;

public class gem : MonoBehaviour {
    
    private Walking _walking;
    public int worth;
    private void Start() {
        _walking = FindObjectOfType<Walking>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _walking.coins += worth;
            SoundManager.instance.PlayXpCollection();
            gameObject.SetActive(false);
        }
    }
}

using UnityEngine;

public class gem : MonoBehaviour {
    
    private Walking _walking;
    public int worth;
    [SerializeField] Animator gem_animator;
    private void Start() {
        _walking = FindObjectOfType<Walking>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            gem_animator.enabled = true;
            _walking.coins += _walking.combo;
            SoundManager.instance.PlayXpCollection();
        }
    }
}

using UnityEngine;

public class enemy : MonoBehaviour
{
    private DeadManager _deadManager;
    public Vector3 penguin;
    public Animator animator;
    public bool isTree;
    
    private void Awake() {
        _deadManager = FindObjectOfType<DeadManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            if (isTree) {
                
                animator.enabled = true;
                if (!Walking.Instance.fromLeft) {
                    transform.Rotate(0, -90f, 0);
                } 
                
                penguin = other.transform.position;
                other.transform.position = new Vector3(penguin.x, penguin.y - 2, penguin.z);
                _deadManager.dead = true;
            }
            else _deadManager.dead = true;
        }
    }
}

using UnityEngine;

public class enemy : MonoBehaviour
{
    private DeadManager _deadManager;
    public Vector3 penguin;
    public Animator animator;
    public bool isTree;
    private void Awake()
    {
        _deadManager = FindObjectOfType<DeadManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (isTree)
            {
                animator.enabled = true;
                if (!other.gameObject.GetComponent<Walking>().from_left )
                {
                    transform.Rotate(0, -90, 0);
                    
                } 
                if (other.GetComponent<Walking>().heart==0)
                {
                    penguin = other.transform.position;
                    other.gameObject.transform.position = new Vector3(penguin.x, penguin.y - 2, penguin.z);
                    _deadManager.dead = true;
                    
                }
                else
                {
                    other.GetComponent<Walking>().heart -= 1;
                }
            }
            else
            {
                _deadManager.dead = true;
            }
            
        }
    }
}

using UnityEngine;

public class enemy : MonoBehaviour
{
    private DeadManager _deadManager;
    public Vector3 penguin;
    public GameObject tree;
    public GameObject treean;
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
                penguin = other.transform.position;
                other.gameObject.transform.position = new Vector3(penguin.x, penguin.y - 2, penguin.z);
                treean.SetActive(true);
                Destroy(tree);
                if (!other.gameObject.GetComponent<Walking>().from_left )
                {
                    transform.Rotate(0, -90, 0);
                    
                } 
                
            }
            _deadManager.dead = true;
        }
    }
}

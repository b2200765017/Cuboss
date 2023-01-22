using UnityEngine;

public class gem : MonoBehaviour
{
    //private Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            //animator = transform.GetComponent<Animator>();
            //animator.SetTrigger("collect");
            Walking _walking = other.transform.GetComponent<Walking>();
            _walking._coins++;
            _walking.sounds.gem_collected();
            gameObject.SetActive(false);
        }
    }
}

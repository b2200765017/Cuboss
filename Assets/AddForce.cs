using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody.AddForce(transform.forward*100f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

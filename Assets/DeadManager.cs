using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DeadManager : MonoBehaviour
{
    [SerializeField] public Transform _dead;
    public bool dead = false;
    private Transform _transform;
    void Start()
    {
        _transform = gameObject.transform;
    }
    void Update()
    {
        float value = Mathf.Abs(_transform.position.x + _transform.position.z);
        if (value > 9.6f | Input.GetKeyDown(KeyCode.H))
        {
            dead = true;
            _dead.gameObject.SetActive(true);
            _dead.position = _transform.position;
            _dead.rotation = _transform.rotation;
            if (Mathf.Abs(_transform.position.x) >  Mathf.Abs(_transform.position.z))
            {
                _dead.GetComponent<Rigidbody>().AddForce(new Vector3(-200,200f,0), ForceMode.Force);
            }
            else
            {
                _dead.GetComponent<Rigidbody>().AddForce(new Vector3(0,200f,200), ForceMode.Force);
            }
            gameObject.SetActive(false);
        }
    }
}

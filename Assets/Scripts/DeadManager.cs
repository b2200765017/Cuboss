using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class DeadManager : MonoBehaviour
{
    public bool dead = false;
    private Transform _transform;
    private Walking _walking;
    [SerializeField] private CameraMovement _cameraMovement;
    void Start()
    {
        _transform = gameObject.transform;
        _walking = GetComponent<Walking>();
    }
    void Update()
    {
        float value = Mathf.Abs(_transform.position.x + _transform.position.z);

        if (value > 7.6f |dead)
        {
            _cameraMovement.enabled = false;
            _walking._isplay = false;
            gameObject.AddComponent<Rigidbody>();
            //_dead.gameObject.SetActive(true);
            //_dead.position = _transform.position;
            //_dead.rotation = _transform.rotation;
            float random = Random.Range(100, 120) * _walking._rollSpeed;
            if (!_walking.from_left)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-random,400,0), ForceMode.Force);
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,400,random), ForceMode.Force);
            }
            
            //gameObject.SetActive(false);
            this.enabled = false;
        }
    }
}

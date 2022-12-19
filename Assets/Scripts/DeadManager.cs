using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DeadManager : MonoBehaviour
{
    public bool dead = false;
    private Transform _transform;
    private Walking _walking;
    public GameObject _restart;
    [SerializeField] private bestScore _bestScore;
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
            Handheld.Vibrate();
            Debug.Log(_walking._points);
            if (_walking._points > PlayerPrefs.GetInt("hs"))
            {
                PlayerPrefs.SetInt("hs",_walking._points);
            }
            _cameraMovement.enabled = false;
            _walking._isplay = false;
            //_dead.gameObject.SetActive(true);
            //_dead.position = _transform.position;
            //_dead.rotation = _transform.rotation;
            float random = Random.Range(200, 300) * _walking._rollSpeed;
            if (!_walking.from_left)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-random,400,0), ForceMode.Force);
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,400,random), ForceMode.Force);
            }
            _restart.SetActive(true);
            //gameObject.SetActive(false);
            this.enabled = false;
            dead = false;
        }
    }
}

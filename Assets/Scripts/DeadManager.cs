using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DeadManager : MonoBehaviour
{
    public bool dead = false;
    private Transform _transform;
    private Walking _walking;
    public GameObject _restart;
    public TextMeshProUGUI score;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI coins1;
    [SerializeField] private CameraMovement _cameraMovement;
    void Start()
    {
        _transform = gameObject.transform;
        _walking = GetComponent<Walking>();
    }
    void Update()
    {
        float value = Mathf.Abs(_transform.position.x + _transform.position.z);
        if (value > 8.5f |dead)
        {
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
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-random,1000,0), ForceMode.Force);
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,1000,random), ForceMode.Force);
            }
            _restart.SetActive(true);
            score1.text = score.text;
            score.gameObject.SetActive(false);
            coins1.text = coins.text;
            coins.gameObject.SetActive(false);
            //gameObject.SetActive(false);
            this.enabled = false;
            dead = false;
        }
    }
}

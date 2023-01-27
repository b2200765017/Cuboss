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
    [SerializeField] private Walking _walking;
    public GameObject _restart;
    public TextMeshProUGUI score;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI coins;
    public TrailRenderer trail;
    public TextMeshProUGUI coins1;
    [SerializeField] private bestScore _bestScore;
    [SerializeField] private CameraMovement _cameraMovement;
    void Start()
    {
        _transform = gameObject.transform;
    }
    void Update()
    {
        float value = Mathf.Abs(_transform.position.x + _transform.position.z);
        if (value > 8.5f | dead)
        {
            if (_walking._points > PlayerPrefs.GetInt("hs"))
            {
                PlayerPrefs.SetInt("hs",_walking._points);
            }
            _cameraMovement.enabled = false;
            _walking._isplay = false;
            float random = Random.Range(25, 25) * _walking._rollSpeed;
            trail.emitting = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            if (!_walking.from_left)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-random,20,0), ForceMode.Force);
                
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,20,random), ForceMode.Force);
            }
            _restart.SetActive(true);
            score1.text = score.text;
            score.gameObject.SetActive(false);
            coins1.text = coins.text;
            coins.gameObject.SetActive(false);
            //gameObject.SetActive(false);
            dead = false;
            this.enabled = false;
        }
    }
}

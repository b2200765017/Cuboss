using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _points;
    [SerializeField] GameObject player;
    [SerializeField] GameObject _playButton;
    [SerializeField] TextMeshProUGUI _coins;
    [SerializeField] GameObject _restartButton;
    [SerializeField] DeadManager _deadManager;
    [SerializeField] GameObject  _foto;
    

    private Walking _walking;
    // Start is called before the first frame update
    void Start()
    {
        _walking = player.GetComponent<Walking>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_points.text == "31")_foto.SetActive(true);
        if(_points.text == "32")_foto.SetActive(false);
        if (_deadManager.dead)
        {
            _restartButton.SetActive(true);
        }

        _points.text = _walking._points.ToString();
        _coins.text = _walking._coins.ToString();
    }

    public void OnPlayButtonDown()
    {
        player.GetComponent<Walking>()._isplay = true;
        _playButton.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

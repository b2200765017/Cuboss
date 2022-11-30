using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _points;
    [SerializeField] GameObject player;
    [SerializeField] GameObject _playButton;

    private Walking _walking;
    // Start is called before the first frame update
    void Start()
    {
        _walking = player.GetComponent<Walking>();
    }

    // Update is called once per frame
    void Update()
    {
        _points.text =_walking._points.ToString();
    }

    public void OnPlayButtonDown()
    {
        player.GetComponent<Walking>()._isplay = true;
        _playButton.SetActive(false);
    }
}

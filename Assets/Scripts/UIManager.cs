using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _points;
    [SerializeField] GameObject player;
    [SerializeField] GameObject _playButton;
    [SerializeField] TextMeshProUGUI _coins;
    [SerializeField] TextMeshProUGUI _time;
    [SerializeField] GameObject restartButton;
    [SerializeField] DeadManager _deadManager;
    [SerializeField] TextMeshProUGUI _fps;
    public float timeLeft=3;
    private bool gameStarted=false;

    private Walking _walking;
    // Start is called before the first frame update
    void Start()
    {
        _time.text = "3";
        Application.targetFrameRate = 500;
        QualitySettings.vSyncCount = 0;
        _walking = player.GetComponent<Walking>();
    }

    // Update is called once per frame
    void Update()
    {
        _fps.text = (1 / Time.deltaTime).ToString();
        if (_deadManager.dead)
        {
            restartButton.SetActive(true);
        }

        _points.text = _walking._points.ToString();
        _coins.text = _walking._coins.ToString();
        if (!gameStarted)
        {
            _time.text = ((int) timeLeft+1).ToString();
            timeLeft -= Time.deltaTime;
        }
        
        if ( timeLeft < 0 && !gameStarted )
        {
            gameStarted = true;
            _time.text = "";
            OnPlayButtonDown();
        }
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
    public void MainButton()
    {
        SceneManager.LoadScene(0);
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI _time;
    [SerializeField] GameObject restartButton;
    [SerializeField] DeadManager _deadManager;
    public float timeLeft=3;
    private bool gameStarted=false;
    
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI coinsText;
    private int _points;
    private int _coins;
    
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
        if (_deadManager.dead)
        {
            restartButton.SetActive(true);
        }
        

        if (_points != _walking._points)
        {
            pointsText.text = _walking._points.ToString();
            _points = _walking._points;
        }

        if (_coins != _walking._coins)
        {
            coinsText.text = _walking._coins.ToString();
            _coins = _walking._coins;
        }

        if (!gameStarted)
        {
            _time.text = ((int) timeLeft+1).ToString();
            timeLeft -= Time.deltaTime;
            if ( timeLeft < 0 && !gameStarted )
            {
                gameStarted = true;
                _time.text = "";
                _walking._isplay = true;
            }
        }
        

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

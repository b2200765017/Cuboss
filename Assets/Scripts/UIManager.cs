using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject restartButton;
    [SerializeField] DeadManager _deadManager;
    public float timeLeft=3;
    private bool gameStarted=false;
    
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] TextMeshProUGUI heartText;
    
    private int _points;
    private int _coins = 0;
    private int _hearts;
    private Animator _animator;
    private Walking _walking;
    // Start is called before the first frame update
    void Start()
    {
        _walking = player.GetComponent<Walking>();

    }

    private void PlayClickSound()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            timeLeft -= Time.deltaTime;
            if ( timeLeft < 0 && !gameStarted )
            {
                gameStarted = true;
                _walking.isplay = true;
            }
        }
        else
        {
            if (_deadManager.dead)
            {
                restartButton.SetActive(true);
            }
        
            if (_points != _walking.points)
            {
                pointsText.text = _walking.points.ToString();
                _points = _walking.points;
            }

            if (_coins != _walking.coins)
            {
                coinsText.text = _walking.coins.ToString();
                _coins = _walking.coins;
            }if (_hearts != _walking.heart)
            {
                heartText.text = _walking.heart.ToString();
                _hearts = _walking.heart;
            }       
        }
        

    }
    

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        SoundManager.instance.Play("Click");
    }
    public void MainButton()
    {
        SceneManager.LoadScene(0);
        SoundManager.instance.Play("Click");
    }
}

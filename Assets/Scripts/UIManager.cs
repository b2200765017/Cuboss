using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    
    [SerializeField] GameObject restartButton;
    [SerializeField] DeadManager _deadManager;
    public float timeLeft=3;
    private bool gameStarted;
    
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] TextMeshProUGUI heartText;
    
    private int _points;
    private int _coins;
    private int _hearts;
    private Animator _animator;
    private Walking _walking;

    void Start() {
        _walking = Walking.Instance;
    }
    
    // Make events for UI whenever a change is occured.
    void Update()
    {
        if (!gameStarted) {
            
            timeLeft -= Time.deltaTime;
            if ( timeLeft < 0 && !gameStarted ) {
            
                gameStarted = true;
                _walking.isplay = true;
            }
        }
        else {
            
            if (_deadManager.dead) {
                
                restartButton.SetActive(true);
            }
        
            if (_points != _walking.points) {
                
                pointsText.text = _walking.points.ToString();
                _points = _walking.points;
            }

            if (_coins != _walking.coins) {
                
                coinsText.text = _walking.coins.ToString();
                _coins = _walking.coins;
            }
            if (_hearts != _walking.heart) {
                
                heartText.text = _walking.heart.ToString();
                _hearts = _walking.heart;
            }       
        }
    }
    

    public void RestartButton() {
        
        SoundManager.instance.Play("Click");
        SceneManager.LoadScene(1);
    }
    public void MainButton() {
        
        SoundManager.instance.Play("Click");
        SceneManager.LoadScene(0);
    }
}

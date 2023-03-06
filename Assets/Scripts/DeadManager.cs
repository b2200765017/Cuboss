using TMPro;
using UnityEngine;

public class DeadManager : MonoBehaviour
{
    [SerializeField] private Walking _walking;
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField] private Rigidbody _rb;
    private Transform _transform;

    public bool dead;
    public TrailRenderer trail;
    public GameObject _restart;
    public ParticleSystem watersplash;
    private int _highestScore;
    private float PlayerOffset;
    private float RandomValue;


    [Header("UI Elements")]
    public TextMeshProUGUI score;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI coins1;

    void Start()
    {
        _transform = transform;
        _highestScore = PlayerPrefs.GetInt("hs");
    }
    void Update()
    {
        PlayerOffset = Mathf.Abs(_transform.position.x + _transform.position.z);
        if (PlayerOffset > 8.5f | dead)
        {
            // Setting the Highest Score 
            if (_walking.points > _highestScore)  PlayerPrefs.SetInt("hs",_walking.points);

            // Disabling Scripts
            _cameraMovement.enabled = false;
            _walking.isplay = false;
            trail.emitting = false;
            
            RandomValue = Random.Range(25, 25) * _walking.rollSpeed;

            // Physical Interaction with Player
            _rb.useGravity = true;
            if (!_walking.fromLeft)  _rb.AddForce(new Vector3(-RandomValue,20,0), ForceMode.Force);
            else _rb.AddForce(new Vector3(0,20,RandomValue), ForceMode.Force);
            
            
            SoundManager.instance.Play("GameOver");
            watersplash.Play();
            UIAnimator.Instance.OnGameEnd();
            
            // Setting UI Elements
            _restart.SetActive(true);
            score1.text = score.text;
            coins1.text = coins.text;
            
            score.enabled = false;
            coins.enabled = false;

            PlayerPrefs.SetInt(GemManager.Instance.GetGemString(), PlayerPrefs.GetInt(GemManager.Instance.GetGemString(), 0) + _walking.coins);
            enabled = false;
        }
    }
}

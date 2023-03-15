using System.Collections;
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
    public Canvas canvas;
    public bool isTree = false;

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
            
            RandomValue = Random.Range(15, 20) * _walking.rollSpeed;
            if (RandomValue < 200) RandomValue = 200;
            else if (RandomValue > 350) RandomValue = 350;
            Debug.Log(RandomValue);

                // Physical Interaction with Player
            _rb.useGravity = true;
            if (!_walking.fromLeft)  _rb.AddForce(new Vector3(-RandomValue,140,0), ForceMode.Force);
            else _rb.AddForce(new Vector3(0,140,RandomValue), ForceMode.Force);

            if (!isTree) StartCoroutine(DelayedSFX());
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
            canvas.enabled = false;
        }
    }
    IEnumerator DelayedSFX()
    {
        yield return new WaitForSeconds(0.6f);
        SoundManager.instance.Play("WaterDrop");
    }
}

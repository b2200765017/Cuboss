using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeadManager : MonoBehaviour
{
    private const string GEM_COUNT = "GemCount";
    
    public bool dead;
    private Transform _transform;
    [SerializeField] private Walking _walking;
    public GameObject _restart;
    public TextMeshProUGUI score;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI coins;
    public TrailRenderer trail;
    public TextMeshProUGUI coins1;
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField] private Button rewardAds;
    void Start()
    {
        _transform = gameObject.transform;
    }
    void Update()
    {
        float value = Mathf.Abs(_transform.position.x + _transform.position.z);
        if (value > 8.5f | dead)
        {
            rewardAds.interactable = true;
            if (_walking.points > PlayerPrefs.GetInt("hs"))
            {
                PlayerPrefs.SetInt("hs",_walking.points);
            }
            _cameraMovement.enabled = false;
            _walking.isplay = false;
            float random = Random.Range(25, 25) * _walking.rollSpeed;
            trail.emitting = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            if (!_walking.fromLeft)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-random,20,0), ForceMode.Force);
                
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,20,random), ForceMode.Force);
            }
            SoundManager.instance.Play("GameOver");
            PlayerPrefs.SetInt(GEM_COUNT, PlayerPrefs.GetInt(GEM_COUNT, 0) + _walking.coins);
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

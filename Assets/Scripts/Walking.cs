using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
public class Walking : MonoBehaviour
{
    public float rollSpeed = 5;
    [SerializeField] private GameObject highscoreObject;
    public int heart;
    public int heartp;
    public int points;
    public int coins;
    public bool isplay;
    private bool _isMoving;
    public bool fromLeft;
    public bool isLeft = true;
    public SoundManager sounds;
    [SerializeField] private TextMeshProUGUI highscore;
    private TextMeshPro _highScore;
    private GameObject _box;
    public World_Manager worldManager;
    private float _playerOffset;
    private int highScore;
    [SerializeField] private Transform penguen;
    [SerializeField] public float rotation_speed = 2f;
    private float yValue;
    

    private Transform particleTransform;
    [SerializeField] private ParticleSystem _particleSystem;

    private void Start()
    {
        sounds = FindObjectOfType<SoundManager>();
        particleTransform = _particleSystem.gameObject.transform;
        _highScore = highscoreObject.GetComponentInChildren<TextMeshPro>();
        highScore = PlayerPrefs.GetInt("hs");
        highscore.text = highScore.ToString();
        _highScore.text += highScore.ToString();
        if (highScore >= 10)
        {
            highscoreObject.transform.position = new Vector3(-(highScore * 2) + 3, 0, (highScore * 2) - 3);
        }
        Time.timeScale = 1;
    }

    private void Update()
    {
        float t = Time.deltaTime;
        if (isLeft)
        {
            penguen.rotation = Quaternion.Slerp(penguen.rotation, Quaternion.Euler(0, -90, 0), t * rotation_speed);
        }
        else
        {
            penguen.rotation = Quaternion.Slerp(penguen.rotation, Quaternion.Euler(0, 0, 0), t * rotation_speed);
        }

        if (worldManager.offset - _playerOffset < 20)
        {
            int index = Random.Range(0, worldManager._patternsList.Count);
            worldManager.prefabPattern(worldManager._patternsList[index]);
        }

        if (isplay)
        {
            if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space))
            {
                SoundManager.instance.PlaySlide();
                _particleSystem.Play();
                
                yValue = (particleTransform.localEulerAngles.y + 180f) % 360;
                particleTransform.eulerAngles = new Vector3(0,  yValue, 0);
                isLeft = !isLeft;
                Rotating();
                return;
            }

            Rotating();
        }
    }

    public void Rotating()
    {
        var position = transform.position;
        _playerOffset = (-position.x + position.z + 4) / 4;
        points = (int)_playerOffset;


        Assemble();

        if (isLeft)
        {
            fromLeft = false;
            transform.Translate(Vector3.left * (Time.deltaTime * rollSpeed));
        }
        else
        {
            fromLeft = true;
            transform.Translate(Vector3.forward * (Time.deltaTime * rollSpeed));
        }

    }

    public void Assemble()
    {
        if (rollSpeed < 10 &&rollSpeed >= 7)   rollSpeed += 5*Time.deltaTime / 10;
        
        else if (rollSpeed < 7)    rollSpeed += 5f*Time.deltaTime / 10;
        
        else if(rollSpeed > 10 && rollSpeed<15)   rollSpeed += Time.deltaTime / 20;
        
        else rollSpeed +=   Time.deltaTime / 30;
        
    }
    
}
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
public class Walking : MonoBehaviour {
    
    public static Walking Instance;

    [SerializeField] private Transform penguen;
    [SerializeField] private Transform SnowPivot;
    [SerializeField] public float rotation_speed = 2f;
    [SerializeField] public float rollspeedslowmul = 2f;
    [SerializeField] private GameObject highscoreObject;
    [SerializeField] private TextMeshProUGUI highscore;
    
    public float rollSpeed = 5;
    public float boostspeed = 5;
    public int heart;
    public int heartp;
    public int points;
    public int coins;
    public bool isplay;
    private bool _isMoving;
    public bool fromLeft;
    public bool isLeft = true;
    private TextMeshPro _highScore;
    private GameObject _box;
    public World_Manager worldManager;
    private float _playerOffset;
    private bool boosting = false;

    private int highScore;
    private float yValue;
    

    private Transform particleTransform;
    [SerializeField] private ParticleSystem _particleSystem;

    private void Awake() {
        
        if (Instance != null && Instance != this) { 
            Destroy(this); 
        } 
        else { 
            Instance = this; 
        } 
    }

    private void Start() {
        particleTransform = _particleSystem.gameObject.transform;
        _highScore = highscoreObject.GetComponentInChildren<TextMeshPro>();
        highScore = PlayerPrefs.GetInt("hs");
        highscore.text = highScore.ToString();
        _highScore.text += highScore.ToString();
        if (highScore >= 10) {
            highscoreObject.transform.position = new Vector3(-(highScore * 2) + 3, 0, (highScore * 2) - 3);
        }
    }

    private void Update() {

        if (boosting)
        {
            if (boostspeed <5)
                boostspeed += 4*Time.deltaTime*rollspeedslowmul;
            else
            {
                boosting = false;
            }
        }
        else
        {
            if (boostspeed >0)
                boostspeed -= Time.deltaTime*rollspeedslowmul; 
        }
        
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
                Turn();
                return;
            }

            Rotating();
        }
    }

    void Turn()
    {
        SoundManager.instance.PlaySlide();
        _particleSystem.Play();
        yValue = (90f-particleTransform.localEulerAngles.y + 180f);
        particleTransform.eulerAngles = new Vector3(0,  yValue, 0);
        isLeft = !isLeft;
        Rotating();
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
            transform.Translate(Vector3.left * (Time.deltaTime * (rollSpeed+boostspeed)));
        }
        else
        {
            fromLeft = true;
            transform.Translate(Vector3.forward * (Time.deltaTime * (rollSpeed+boostspeed)));
        }

    }

    public void Assemble()
    {
        if (rollSpeed < 10 &&rollSpeed >= 7)   rollSpeed += 5*Time.deltaTime / 10;
        
        else if (rollSpeed < 7)    rollSpeed += 7f*Time.deltaTime / 10;
        
        else if(rollSpeed > 10 && rollSpeed<15)   rollSpeed += Time.deltaTime / 8;
        
        else rollSpeed +=   Time.deltaTime / 10;
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        WallCooldown wall;
        if (other.transform.TryGetComponent(out wall))
        {
            if (wall.isHit)return;
            wall.isHit = true;
            boosting = true;
            if (wall.isLeft && fromLeft)
            {
                Turn();
            }
            else if(!wall.isLeft && !fromLeft)
            {
                Turn();
            }
            
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        WallCooldown wall;
        if (other.transform.TryGetComponent(out wall))
        {
            if (!wall.isHit)return;
            wall.isHit = false;
        }
    }
}
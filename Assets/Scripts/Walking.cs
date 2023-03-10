using TMPro;
using UnityEngine;
using UnityEngine.UI;
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
    public int combo = 1;
    public float combotimer = 20;
    public World_Manager worldManager;
    private float _playerOffset;
    private bool boosting = false;
    private int highScore;
    private float yValue;
    private float t;
    private Vector3 newVector;
    private WallCooldown wall;
    
    

    private Transform particleTransform;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Image timer;
    public TextMeshProUGUI ComboText;

    private void Awake() {
        
        if (Instance != null && Instance != this) { 
            Destroy(this); 
        } 
        else { 
            Instance = this; 
        } 
    }

    private void Start()
    {
        newVector.x = 0;
        newVector.z = 0;
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

        Boost();
        Combo();
        // Rotating the Player With a slerp function
        t = Time.deltaTime;
        if (isLeft)
        {
            penguen.rotation = Quaternion.Slerp(penguen.rotation, Quaternion.Euler(0, -90, 0), t * rotation_speed);
        }
        else
        {
            penguen.rotation = Quaternion.Slerp(penguen.rotation, Quaternion.Euler(0, 0, 0), t * rotation_speed);
        }
        
        // Pattern Creation script
        if (worldManager.offset - _playerOffset < 20) {
            worldManager.prefabPattern(worldManager._patternsList[Random.Range(0, worldManager._patternsList.Count)]);
        }

        if (isplay) {
            if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space)) {
                Turn();
            }
            Rotating();
        }
    }

    private void Combo()
    {
        if (combo > 1)
        {
            if (combotimer > 0)
            {
             combotimer -= Time.deltaTime;
             timer.fillAmount = combotimer / 20;
             if(combotimer / 20<0.1) 
                 ComboText.alpha = combotimer;
            }
            else
            {
                combo = 1;
                ComboText.text = null;
            }
        }
        
    }
    private void Boost() {
        if (boosting) {
            
            if (boostspeed < 5) boostspeed += 6 * Time.deltaTime * rollspeedslowmul;
            else {
                boosting = false;
            }
        }
        else {
            if (boostspeed > 0) boostspeed -= Time.deltaTime * rollspeedslowmul;
        }
    }

    void Turn() {
        SoundManager.instance.PlaySlide();
        _particleSystem.Play();
        
        yValue = (90f-particleTransform.localEulerAngles.y + 180f);
        newVector.y = yValue;
        particleTransform.eulerAngles = newVector;
        isLeft = !isLeft;
    }

    public void Rotating()
    {
        var position = transform.position;
        _playerOffset = (-position.x + position.z + 4) / 4;
        points = (int)_playerOffset;
        
        AssigningRollSpeed();

        if (isLeft) {
            
            fromLeft = false;
            transform.Translate(Vector3.left * (Time.deltaTime * (rollSpeed+boostspeed)));
        }
        else {
            
            fromLeft = true;
            transform.Translate(Vector3.forward * (Time.deltaTime * (rollSpeed+boostspeed)));
        }
    }
    
    public void AssigningRollSpeed() {
        if(rollSpeed<=3)   rollSpeed += 15*Time.deltaTime;
        else if (3 < rollSpeed && rollSpeed <= 7)  rollSpeed += (5f*Time.deltaTime);
        else if (rollSpeed > 7 && rollSpeed <= 10) rollSpeed += (Time.deltaTime) / 4;
        else if (rollSpeed > 10 && rollSpeed<= 15)   rollSpeed += (Time.deltaTime) / 10;
        else rollSpeed +=   (Time.deltaTime) / 12;
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.transform.TryGetComponent(out wall)) {
            if (wall.isHit)return;
            wall.isHit = true;
            boosting = true;
            if (wall.isLeft && fromLeft) {
                Turn();
            }
            else if(!wall.isLeft && !fromLeft) {
                Turn();
            }
        }
        else if (other.transform.CompareTag("combo"))
        {
            other.GetComponent<Animator>().SetTrigger("combo");
            combotimer = 20;
            combo=combo*2;
            ComboText.text = combo.ToString()+"X";
            ComboText.alpha = 1;
        }
    }
    
    private void OnTriggerExit(Collider other) {
        if (other.transform.TryGetComponent(out wall)) {
            if (!wall.isHit)return;
            wall.isHit = false;
        }
    }
}
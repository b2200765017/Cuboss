using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

/*public class Walking : MonoBehaviour {
    [SerializeField] public float _rollSpeed = 5;
    private Transform box;
    public int _points;
    public int _coins;
    public bool _isplay=false;
    private bool _isMoving;
    public bool from_left = false;
    public bool is_left = true;
    public DeadManager _dead; 
    public Sounds sounds;
    public TextMeshProUGUI highscore;
    private bool is_right = false;
    [SerializeField] LayerMask layerMask;
    private GameObject groundObj;
    private bool loop= false;
    private World_Manager _worldManager;
    private Animator animator;
    private float _playeroffset = 0;
    public int high_score;
    [SerializeField] private GameObject highscore_obj;
    [SerializeField] private Transform Lefttarget;
    [SerializeField] private Transform Righttarget;
    [SerializeField] private Animator _animator;
    private void Start()
    {
        high_score = PlayerPrefs.GetInt("hs");
        Debug.Log(PlayerPrefs.GetInt("hs"));
        highscore.text=high_score.ToString();
        highscore_obj.GetComponentInChildren<TextMeshPro>().text += high_score;
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("music");
        sounds = gameObjects[0].gameObject.GetComponent<Sounds>();
        _worldManager = GetComponent<World_Manager>();
        _dead = GetComponent<DeadManager>();
        if (high_score < 10) return;
        highscore_obj.transform.position = new Vector3(-(high_score*2)+3, 0, (high_score*2)-3);
    }

    private void Update()
    {
        if ((_worldManager.groundPosition - transform.position).magnitude < 60)
        {
            _worldManager.PatternBuilder();
        }
        
        if (_worldManager.offset - _playeroffset < 20 )
        {
          int index = Random.Range(0, _worldManager._patternsList.Count);         
          Patterns pattern = _worldManager._patternsList[index];                  
          _worldManager.prefabPattern(pattern);
        }
        if (_isplay)
        {

            if (_points > high_score)
            {
                highscore.text = _points.ToString();
            }
            if (Input.GetMouseButtonDown(0))
            {
                is_left = !is_left;
                RotationAnimation();
                Rotating();
                return;
            }
            Rotating();
        }



    }

    public void RotationAnimation()
    {
        // if (is_left)
        // {
        //     _animator.SetTrigger("left");
        // }
        // else
        // {
        //     _animator.SetTrigger("right");
        // }
    }
    public void Rotating()
    {
        if (is_left)
        {
            from_left = false;
            Assemble(Vector3.left);
        }
        else
        {
            from_left = true;
            Assemble(Vector3.forward);
        }
    }
        public void Assemble(Vector3 dir)
    {
        _playeroffset = (-transform.position.x + transform.position.z + 4) / 4;
        _points = (int) _playeroffset;
        _rollSpeed += Time.deltaTime / 10;
        transform.Translate(dir * _rollSpeed * Time.deltaTime);  
            
    }
}*/
public class Walking : MonoBehaviour
{
    [SerializeField] public float _rollSpeed = 5;
    [SerializeField] private GameObject highscoreObject;


    public int _points;
    public int _coins;
    public bool _isplay = false;
    private bool _isMoving;
    public bool from_left = false;
    public bool is_left = true;
    public DeadManager _dead;
    public Sounds sounds;
    [SerializeField] private TextMeshProUGUI highscore;
    private TextMeshPro high_score;
    private bool isRight = false;
    private GameObject box;
    private bool loop = false;
    private World_Manager worldManager;
    private Animator characterAnimator;
    private float playerOffset = 0;
    private int highScore;
    [SerializeField] private Transform penguen;
    public float speed = 2f;


    private void Start()
    {
        high_score = highscoreObject.GetComponentInChildren<TextMeshPro>();
        highScore = PlayerPrefs.GetInt("hs");
        highscore.text = highScore.ToString();
        high_score.text += highScore.ToString();

        // Find the "Sounds" object in the scene and cache the reference
        sounds = FindObjectOfType<Sounds>();

        // Cache the reference to the "WorldManager" component
        worldManager = GetComponent<World_Manager>();

        // Cache the reference to the "DeadManager" component
        _dead = GetComponent<DeadManager>();

        if (highScore >= 10)
        {
            highscoreObject.transform.position = new Vector3(-(highScore * 2) + 3, 0, (highScore * 2) - 3);
        }

        Time.timeScale = 1;
    }

    private void Update()
    {
        float t = Time.deltaTime;
        if (is_left)
        {
            penguen.rotation = Quaternion.Slerp(penguen.rotation, Quaternion.Euler(0, -90, 0), t * speed);
        }
        else
        {
            penguen.rotation = Quaternion.Slerp(penguen.rotation, Quaternion.Euler(0, 0, 0), t * speed);
        }
        
        if (Vector3.Distance(worldManager.groundPosition, transform.position) < 60)
        {
            worldManager.PatternBuilder();
        }

        
        if (worldManager.offset - playerOffset < 20)
        {
            int index = Random.Range(0, worldManager._patternsList.Count);
            Patterns pattern = worldManager._patternsList[index];
            worldManager.prefabPattern(pattern);
        }

        if (_isplay)
        {
            if (_points > highScore)
            {
                highscore.text = _points.ToString();
            }

            if (Input.GetMouseButtonDown(0))
            {
                is_left = !is_left;
                Rotating();
                return;
            }

            Rotating();
        }
    }

    public void Rotating()
    {
        if (is_left)
        {
            from_left = false;
            Assemble(Vector3.left);
        }
        else
        {
            from_left = true;
            Assemble(Vector3.forward);
        }
    }

    public void Assemble(Vector3 dir)
    {
        var position = transform.position;
        playerOffset = (-position.x + position.z + 4) / 4;
        _points = (int)playerOffset;
        _rollSpeed += Time.deltaTime / 10;
        transform.Translate(dir * (Time.deltaTime * _rollSpeed));
    }
    
}


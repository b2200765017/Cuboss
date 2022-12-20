using System.Collections;
using TMPro;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Walking : MonoBehaviour {
    [SerializeField] public float _rollSpeed = 5;
    private Transform box;
    public int _points;
    public int _coins;
    public int _combo=1;
    public float loop_i=-1;
    public int delay = 0;
    public bool _playable=true;
    [SerializeField] public float pattern_build_ratio = 0.01f;
    public bool _isplay=false;
    public bool _isCreated=false;
    private bool _isMoving;
    public bool from_left = false;
    public bool is_left = true;
    public DeadManager _dead; 
    public Sounds sounds;
    public TextMeshProUGUI highscore;
    public float roll_delay_time = 0.01f;
    public float roll_wait_time = 0.01f;
    public bool rotation_ch=false;
    private bool is_right = false;
    [SerializeField] LayerMask layerMask;
    private GameObject groundObj;
    private bool onbox = false;
    private bool loop= false;
    private World_Manager _worldManager;
    private Animator animator;
    private float _playeroffset = 0;
    private WaitForSeconds rollDelay;
    public int high_score;
    [SerializeField] private GameObject highscore_obj;
    [SerializeField] private GameObject sagyon;
    [SerializeField] private GameObject solyon;
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
        rollDelay = new WaitForSeconds(roll_delay_time);
        if (high_score < 10) return;
        highscore_obj.transform.position = new Vector3(-high_score+3, 0, high_score-3);
    }

    private void Update()
    {
        if ((_worldManager.groundPosition - transform.position).magnitude < 60)
        {
            _worldManager.PatternBuilder();
        }
        
        if (_worldManager.offset - _playeroffset < 20 && !_worldManager._isstarting)
        {
          //  if (Random.value > pattern_build_ratio ) _worldManager.PatternBuilder();
          //  else
          //  {
          //      int index = Random.Range(0, _worldManager._patternsList.Count);
          //      Patterns pattern = _worldManager._patternsList[index];
          //      _worldManager.prefabPattern(pattern);
          //  }
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
        // transform.position = new Vector3(Mathf.RoundToInt(transform.position.x),
        // Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        // transform.rotation = new Quaternion( 0f,transform.rotation.x, 0f, transform.rotation.z);
        // var anchor = transform.position + (Vector3.down + dir) * 1f;
        // var axis = Vector3.Cross(Vector3.up, dir);
        // anchor = new Vector3(Mathf.RoundToInt(anchor.x), Mathf.RoundToInt(anchor.y), Mathf.RoundToInt(anchor.z));
        // StartCoroutine(Roll(anchor, axis));

        _playeroffset = (-transform.position.x + transform.position.z + 4) / 4;
        _points = (int) _playeroffset;
        _rollSpeed += Time.deltaTime / 30;
        transform.Translate(dir * _rollSpeed * Time.deltaTime);  
            
    }
}
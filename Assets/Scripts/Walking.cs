using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Walking : MonoBehaviour {
    [SerializeField] public float _rollSpeed = 5;
    private Transform box;
    public int _points;
    public int _coins;
    public int _combo=1;
    [SerializeField] public float pattern_build_ratio = 0.01f;
    public bool _isplay=false;
    public bool _isCreated=false;
    private bool _isMoving;
    public bool from_left = false;
    public bool is_left = false;
    public DeadManager _dead;
    public float roll_delay_time = 0.01f;
    public float roll_wait_time = 0.01f;
    
    private bool is_right = false;
    [SerializeField] LayerMask layerMask;
    private GameObject groundObj;
    private bool onbox = false;
    private World_Manager _worldManager;
    private Animator animator;
    private float _playeroffset = 0;
    private WaitForSeconds rollDelay;
    [SerializeField]private Button right_button;
    [SerializeField]private Button left_button;
    
    private void Start()
    {
        _worldManager = GetComponent<World_Manager>();
        _dead = GetComponent<DeadManager>();
        rollDelay = new WaitForSeconds(roll_delay_time);
    }

    private void Update()
    {
        //raycast system
        RaycastHit hit;

        if (Physics.Raycast(transform.position,  Vector3.down, out hit, 2f, layerMask))
        {
            if (hit.transform.tag == "gembox")
            {
                if (!onbox)
                {
                    animator = hit.transform.GetComponent<Animator>();
                    animator.SetBool("collected", true);
                    _coins++;
                }
            }
            else if (hit.transform.tag == "box")
            {
                if (!onbox)
                {
                    box = hit.transform;
                    animator = box.GetComponent<Animator>();
                    animator.SetTrigger("stepped");
                }
            }
            else if (hit.transform.tag == "enemybox")
            {
                if (!onbox)
                {
                    _dead.dead = true;
                    animator = hit.transform.GetComponent<Animator>();
                    animator.SetTrigger("jump");
                    //rb.AddForce(new Vector3(100, -200, 0), ForceMode.Force);
                }
            }

            onbox = true;

        }
        else
        {
            if (box)
            {
                box = null;
                animator.SetTrigger("out");
            }
                onbox = false;
        }

        if (_isplay)
        {
            for (int i = 0; i < Input.touches.Length; i++)
            {
                if (Input.touches[i].position.x < Screen.width / 2 & is_right == false) is_left = true;
                if (Input.touches[i].position.x > Screen.width / 2 & is_left == false) is_right = true;
            }
            if ((Input.GetKey(KeyCode.A)) & is_right == false )                is_left = true;
            if (Input.GetKey(KeyCode.D) & is_left == false)                is_right = true;

            if (Input.GetKeyUp(KeyCode.A)) is_left = false;
            if (Input.GetKeyUp(KeyCode.D)) is_right = false;
        
            if (_isMoving) return;

            if (is_left)
            {
                from_left = false;
                _points+=_combo;
                Assemble(Vector3.left);
            }

            if (is_right)
            {
                from_left = true;
                _points+=_combo;
                Assemble(Vector3.forward);
            }
        }
        // here
        //Debug.Log(_worldManager.offset - _playeroffset < 5);
        if (_worldManager.offset - _playeroffset < 20 && !_worldManager._isstarting)
        {
            if (Random.value > pattern_build_ratio ) _worldManager.PatternBuilder();
            else
            {
                int index = Random.Range(0, _worldManager._patternsList.Count);
                Patterns pattern = _worldManager._patternsList[index];
                _worldManager.prefabPattern(pattern);
            }
        }

        void Assemble(Vector3 dir)
        {
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x),
                Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
            transform.rotation = new Quaternion( 0f,transform.rotation.x, 0f, transform.rotation.z);
            var anchor = transform.position + (Vector3.down + dir) * 1f;
            var axis = Vector3.Cross(Vector3.up, dir);
            anchor = new Vector3(Mathf.RoundToInt(anchor.x), Mathf.RoundToInt(anchor.y), Mathf.RoundToInt(anchor.z));
            StartCoroutine(Roll(anchor, axis));
        }
    }
 
    private IEnumerator Roll(Vector3 anchor, Vector3 axis) {
        _isMoving = true;
        for (var i = 0; i < 90 / _rollSpeed; i++) {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return rollDelay;
            //if (i == 15) _isMoving = true;
        }
        _playeroffset += 0.5f;
        yield return new WaitForSeconds(roll_wait_time);

        _isMoving = false;

        
    }
}
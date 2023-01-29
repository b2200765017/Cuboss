using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;
public class Walking : MonoBehaviour
{
    [SerializeField] public float _rollSpeed = 5;
    [SerializeField] private GameObject highscoreObject;
    public int heart=0;
    public int _points;
    public int _coins;
    public bool _isplay = false;
    private bool _isMoving;
    public bool isulti=false;
    public bool from_left = false;
    public bool is_left = true;
    public DeadManager _dead;
    public Sounds sounds;
    [SerializeField] private TextMeshProUGUI highscore;
    private TextMeshPro high_score;
    private GameObject box;
    public World_Manager worldManager;
    [SerializeField] private Animator characterAnimator;
    private float playerOffset = 0;
    private int highScore;
    [SerializeField] private Transform penguen;
    public float speed = 2f;


    private void Start()
    {
        sounds = FindObjectOfType<Sounds>();
        high_score = highscoreObject.GetComponentInChildren<TextMeshPro>();
        highScore = PlayerPrefs.GetInt("hs");
        highscore.text = highScore.ToString();
        high_score.text += highScore.ToString();
        
        if (highScore >= 10)
        {
            highscoreObject.transform.position = new Vector3(-(highScore * 2) + 3, 0, (highScore * 2) - 3);
        }
        Time.timeScale = 1;
    }

    private void Update()
    {
        float t = Time.deltaTime;
        Vector3 a = new Vector3(0, 0, 0);
        if (is_left)
        {
            penguen.rotation = Quaternion.Slerp(penguen.rotation, Quaternion.Euler(0, -90, 0), t * speed);
        }
        else
        {
            penguen.rotation = Quaternion.Slerp(penguen.rotation, Quaternion.Euler(0, 0, 0), t * speed);
        }
        //characterAnimator.SetFloat("Blend",(penguen.eulerAngles.y-270)/90);

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

            if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space))
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


using UnityEngine;

public class bestScore : MonoBehaviour
{
    public int scorePosition;
    void Awake()
    {
        scorePosition = PlayerPrefs.GetInt("score");
        if (scorePosition < 10) return;
        transform.position = new Vector3(-scorePosition, 0, scorePosition);
    }
    
}

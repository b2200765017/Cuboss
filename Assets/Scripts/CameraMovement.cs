using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - target.position;
    }
     void Update()
    {
        float player_position = (target.position.x - target.position.z) / 2;
        transform.position = new Vector3(player_position + offset.x ,
            transform.position.y, -player_position + offset.z );
    }
}

using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    private Transform Camera;
    private float player_position;
    private Vector3 offset;
    private Vector3 newPosition;
    private Vector3 targetPosition;
    void Start()
    {
        Camera = transform;
        offset = Camera.position - target.position;
    }
     void LateUpdate()
     { 
        targetPosition = target.position;
        player_position = (targetPosition.x - targetPosition.z) / 2;
        newPosition.x = player_position + offset.x;
        newPosition.y = Camera.position.y;
        newPosition.z = -player_position + offset.z;
        Camera.position = newPosition;
    }
}

using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform m_playerTransform;
    private Vector3 cameraOffset;

    void Start()
    {
        cameraOffset = transform.position - m_playerTransform.position;
    }
    void Update()
    {
        float player_position = (m_playerTransform.position.x - m_playerTransform.position.z) / 2;
            transform.position = new Vector3(player_position + cameraOffset.x ,
                transform.position.y, -player_position + cameraOffset.z );
    }
}

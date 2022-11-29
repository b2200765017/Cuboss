using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CameraMovement : MonoBehaviour
{

    public float movingSpeed;
    public Transform m_playerTransform;
    private Vector3 cameraOffset;
    void Start()
    {
        cameraOffset = transform.position - m_playerTransform.position;
    }
    void Update()
    {
        float player_position = (m_playerTransform.position.x - m_playerTransform.position.z) / 2;
        //float offset = vector_offset / Mathf.Pow(2, -2);    
        //float dot = Vector2.Dot(new Vector2(normalized.x, normalized.z), new Vector2(transform.forward.x, transform.forward.z));
        //Debug.Log(dot);
        transform.position = new Vector3(player_position + cameraOffset.x ,
            transform.position.y, -player_position + cameraOffset.z );
    }
}

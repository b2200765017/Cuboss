using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CameraMovement : MonoBehaviour
{

    [CanBeNull] public Transform m_playerTransform;
    private Vector3 cameraOffset;
    private bool _ismPlayerTransformNotNull;

    void Start()
    {
        _ismPlayerTransformNotNull = m_playerTransform != null;
        cameraOffset = transform.position - m_playerTransform.position;
    }
    void Update()
    {
        if (_ismPlayerTransformNotNull)
        {
            float player_position = (m_playerTransform.position.x - m_playerTransform.position.z) / 2;
            transform.position = new Vector3(player_position + cameraOffset.x , transform.position.y, -player_position + cameraOffset.z );  
        }

    }
}

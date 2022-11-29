using System.Collections;
using System.Data;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Walking : MonoBehaviour {
    [SerializeField] private float _rollSpeed = 5;
    private bool _isMoving;
    private bool is_left = false;
    private bool is_right = false;
 
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) & is_right == false) is_left = true;
        if (Input.GetKey(KeyCode.D) & is_left == false) is_right = true;

        if (Input.GetKeyUp(KeyCode.A)) is_left = false;
        if (Input.GetKeyUp(KeyCode.D)) is_right = false;
        
        if (_isMoving) return;

        if (is_left) Assemble(Vector3.left);
        if(is_right) Assemble(Vector3.forward);

 
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
            yield return new WaitForSeconds(0.01f);
        }
        _isMoving = false;
    }
}
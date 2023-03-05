using UnityEngine;
public class destroy : MonoBehaviour {
    
    [SerializeField] private int time;
    void Update() {
        Destroy(gameObject, time);
    }
}

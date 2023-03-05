using UnityEngine;
public class WallCooldown : MonoBehaviour {
    public bool isHit;
    public bool isLeft; 

    private void OnDisable() {
        isHit = false;
    }
}

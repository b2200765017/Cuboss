using UnityEngine;

public class orbScript : MonoBehaviour
{
    public bool istouched = false;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            istouched = true;
            int pieces= Walking.Instance.heartp;
            int heart= Walking.Instance.heart;
            if (heart != 3) {
                if (pieces == 2) {
                    Walking.Instance.heart += 1;
                    Walking.Instance.heartp = 0;
                }
                else {
                    Walking.Instance.heartp += 1;
                }
            }
        }
        Destroy(gameObject);
    }
}

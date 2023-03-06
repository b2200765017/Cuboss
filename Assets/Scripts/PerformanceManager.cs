using UnityEngine;

public class PerformanceManager : MonoBehaviour
{
    public static PerformanceManager Instance;

    void Start()
    {
        Screen.SetResolution(Screen.width,Screen.height, true);
        UnityEngine.Rendering.DebugManager.instance.enableRuntimeUI = false;
        Application.targetFrameRate = -1;
        QualitySettings.vSyncCount = 0;
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

}

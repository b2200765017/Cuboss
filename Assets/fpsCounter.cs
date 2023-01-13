using TMPro;
using UnityEngine;

public class fpsCounter : MonoBehaviour
{
    private float updateInterval = 1.0f;
    private float accum = 0.0f; // FPS accumulated over the interval
    private int frames = 0; // Frames drawn over the interval
    private float timeleft; // Left time for current interval
    [SerializeField]private TextMeshProUGUI fps_counter; // Left time for current interval

    private void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        // Interval ended - update TextMeshPro and start new interval
        if (timeleft <= 0.0)
        {
            // display two fractional digits (f2 format)
            int fps = (int)(accum / frames);
            string format = string.Format("{0:} FPS", fps);
            fps_counter.text = format;

            if (fps < 200)
            {
                fps_counter.color = Color.yellow;
            }
            else
            {
                if (fps < 150)
                {
                    fps_counter.color = Color.red;
                }
                else
                {
                    fps_counter.color = Color.green;
                }
            }
            timeleft = updateInterval;
            accum = 0.0f;
            frames = 0;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{

    public Vector3 time;

    private float hours;
    private float minutes;
    private float seconds;

    public bool pauseStopwatch = true;

    public void StartStopwatch()
    {
        pauseStopwatch = false;
    }
    public void PauseStopWatch()
    {
        pauseStopwatch = true;
    }

    public Vector3 GetTime()
    {
        time = new Vector3(hours, minutes, seconds);
        return time;
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseStopwatch == false)
        {
            StopWatch();
        }
    }

    void StopWatch()
    {
        float time = Time.time;

        seconds = time;
        minutes = time/60;
        hours = time/3600;

    }

}

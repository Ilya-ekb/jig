using System;
using UnityEngine;

public class Train
{
    public float Speed { get; set; }
    bool IsOnStation;
    float TimeOnStation;

    public void Init () {
        IsOnStation = true;
        TimeOnStation = 10;
    }

    void OnStationReaching () {
        while (Speed != 0)
        {
            Speed -= 0.1f;
        }
    }

    void OnStationReached () {
        IsOnStation = true;
        DateTime start = DateTime.Now;
        while ((DateTime.Now - start).TotalMinutes < TimeOnStation)
        {
            continue;
        }

        OnStationLeaved ();
    }

    void OnStationLeaved () {
        while (Speed < 15)
        {
            Speed += 0.1f;
        }
    }
}
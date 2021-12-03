using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;

public class Timer : MonoBehaviour {
    public float timeRemaining = 5.0f;
    private bool timeout = false;

    void Update()
    {
        if (timeRemaining > 0 && !timeout)
        {
            timeRemaining -= Time.deltaTime;
        } 
        else if (!timeout)
        {
            timeRemaining = 0;
            timeout = true;
            Schedule<TimerEnd>();
        }
    }

    public void setTimeRemaining(float time) 
    {
        timeRemaining = time;
        timeout = false;
    }
}
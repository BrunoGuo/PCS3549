using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;

public class TimerEnd : Simulation.Event<TimerEnd>
{
    public override void Execute() 
    {
        Debug.Log("timeout");
        Schedule<PlayerDeath>();
    }
}
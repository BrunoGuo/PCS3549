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
    PlatformerModel model = Simulation.GetModel<PlatformerModel>();
    public override void Execute() 
    {
        Debug.Log("timeout");
        var player = model.player;
        if (player.animator.GetBool("infecting"))
            Schedule<PlayerUntransform>();
        else 
            Schedule<PlayerDeath>();

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using Pink.Constants;

public class PlayerHostDie : Simulation.Event<PlayerHostDie>
{
    public HostController host;
    public PlayerController player;

    public override void Execute()
    {
        
    }
}

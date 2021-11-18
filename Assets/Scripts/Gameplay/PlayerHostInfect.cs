using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using Pink.Constants;

public class PlayerHostInfect : Simulation.Event<PlayerHostInfect>
{
    public HostController host;
    public PlayerController player;

    public override void Execute()
    {
        Debug.Log("Mamou");
        host.IsInfected = true;
        host.gameObject.SetActive(false);
        // Timer timer = player.gameObject.AddComponent<Timer>() as Timer;
        // timer.setTimeRemaining(5);

        player.timer.setTimeRemaining(5);
        //TODO: transformar pink em host
    }
}

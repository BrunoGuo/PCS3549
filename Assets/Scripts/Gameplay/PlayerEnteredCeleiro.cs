using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when a player enters a trigger with a DeathZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredCeleiro"></typeparam>
    public class PlayerEnteredCeleiro : Simulation.Event<PlayerEnteredCeleiro>
    {
        public GameObject layer;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            layer.SetActive(false);
        }
    }
}
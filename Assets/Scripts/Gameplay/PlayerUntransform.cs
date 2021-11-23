using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player untransform.
    /// </summary>
    /// <typeparam name="PlayerUntransform"></typeparam>
    public class PlayerUntransform : Simulation.Event<PlayerUntransform>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            player.changeAnimal(Animal.Type.PINK);
            player.resetAttr();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using Pink.Constants;

public class PlayerPickItem : Simulation.Event<PlayerPickItem>
{
    public GameObject itemObject;
    public GameObject itemUI;
    public ItemController itemController;
    public PlayerController player;

    public override void Execute()
    {
        itemObject.SetActive(false);
        itemUI.SetActive(false);
        if (itemController != null) {
            player.addItem(itemController);
        }
    }
}

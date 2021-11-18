using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;

public class ItemController : MonoBehaviour {

    public GameObject itemObject;
    public GameObject itemUI;

    void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            var ev = Schedule<PlayerPickItem>();
            ev.itemObject = itemObject;
            ev.itemUI = itemUI;
            ev.itemController = this;
            ev.player = player;
        }
    }

    public void reset()
    {
        itemObject.SetActive(true);
        itemUI.SetActive(true);
    }
}
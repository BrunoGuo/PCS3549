using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using Platformer.Mechanics;

/// <summary>
/// Celeiro components mark a collider which will schedule a
/// PlayerEnteredCeleiro event when the player enters the trigger.
/// </summary>
public class Celeiro : MonoBehaviour
{
    public GameObject layer;

    void OnTriggerEnter2D(Collider2D collider)
    {
        var p = collider.gameObject.GetComponent<PlayerController>();
        if (p != null)
        {
            var ev = Schedule<PlayerEnteredCeleiro>();
            ev.layer = layer;
        }
    }


    private void OnTriggerExit2D(Collider2D other) {
        layer.SetActive(true);
    }
}

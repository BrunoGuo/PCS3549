using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using Platformer.Mechanics;

public class CeleiroController : MonoBehaviour
{
    public GameObject fora;
    public GameObject dentro;

    private void Start() {
        GameEvents.current.onCeleiroEnter += onEnter; 
        GameEvents.current.onCeleiroLeave += onLeave;
    }

    private void onEnter()
    {
        fora.SetActive(false);
        dentro.SetActive(true);
    }

    private void onLeave()
    {
        fora.SetActive(true);
        dentro.SetActive(false);
    }
}

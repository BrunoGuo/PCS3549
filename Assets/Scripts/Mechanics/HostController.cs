using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;

public class HostController : MonoBehaviour {
    public bool CanFly  = false;
    public bool CanCarry  = false;
    public float Speed  = 0.0f;
    public bool IsInfected  = false;
    private SpriteRenderer m_SpriteRenderer;
    private bool transforming = false;

    void Start() {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null && transforming && !IsInfected)
        {
            Debug.Log("F");
            var ev = Schedule<PlayerHostInfect>();
            ev.host = this;
            ev.player = player;
        }
    }

    private void Update() {
        if (IsInfected) {
            m_SpriteRenderer.color = Color.red;
        }

        if (Input.GetKey(KeyCode.F)) {
            transforming = true;
        } else {
            transforming = false;
        }
    }
}
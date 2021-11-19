using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;

public class HostController : MonoBehaviour {
    public bool canFly  = false;
    public bool canCarry  = false;
    public float speed  = 0.0f;
    public bool isInfected  = false;
    private SpriteRenderer m_SpriteRenderer;
    private bool transforming = false;

    public Animal.Type animal;

    private Animator animator;

    void Start() {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null && transforming && !isInfected)
        {
            var ev = Schedule<PlayerHostInfect>();
            ev.host = this;
            ev.player = player;
        }
    }

    private void Update() {
        if (isInfected) 
        {
            m_SpriteRenderer.color = Color.red;
        }

        if (Input.GetKey(KeyCode.F)) 
        {
            transforming = true;
        } else {
            transforming = false;
        }
    }
}
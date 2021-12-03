using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

public class NaveController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private PlayerController m_playerController;

    void Start()
    {
        m_playerController = player.GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (m_playerController.items.Count == 3) 
        {
            GameEvents.current.Win();
        }
    }

}

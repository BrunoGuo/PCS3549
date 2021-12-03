using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PortaController : MonoBehaviour
{
    private bool open = false;
    private TilemapRenderer tilemapRenderer;
    public GameObject fora;

    private void Start() 
    {
        tilemapRenderer = GetComponent<TilemapRenderer>();
    }
    private bool onTrigger = false;

    private void OnTriggerEnter2D(Collider2D other) {
       onTrigger = true; 
    }
    private void OnTriggerExit2D(Collider2D other) {
       onTrigger = false; 
    }

    private void Update()
    {
        if (onTrigger) {
            if (Input.GetKeyDown(KeyCode.E) && !open && !fora.activeSelf)
            {
                tilemapRenderer.enabled = false;
                open = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && open)
            {
                if (fora.activeSelf)
                {
                    GameEvents.current.CeleiroEnter();
                } 
                else
                {
                    GameEvents.current.CeleiroLeave();
                }
            }
        }
    }
}

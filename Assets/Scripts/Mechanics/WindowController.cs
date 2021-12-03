using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WindowController : MonoBehaviour
{
    private bool open = false;
    private TilemapRenderer tilemapRenderer;

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
        
        if (onTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E) && !open)
            {
                DestroyImmediate(tilemapRenderer);
                open = true;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                if (GameEvents.current)
                {
                    GameEvents.current.CeleiroEnter();
                }
            }
        }
    }
}

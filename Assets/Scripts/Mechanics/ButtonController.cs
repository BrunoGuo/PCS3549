using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        GameEvents.current.Charge(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        GameEvents.current.Charge(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    private void Start() 
    {
        GameEvents.current.onFinishedCharging += onFinishedCharging;
    }
    
    private void onFinishedCharging() 
    {
        // gameObject.SetActive(true);
        gameObject.transform.position = new Vector3(-55.34f, -0.7f, 0);
    }
}

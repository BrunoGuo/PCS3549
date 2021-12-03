using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {
    public static GameEvents current;

    private void Awake() 
    {
        current = this;
    }

    public event Action onCeleiroEnter;
    public event Action onCeleiroLeave;
    public event Action<GameObject> onBreak;
    public event Action<bool> onCharge;
    public event Action onFinishedCharging;
    public event Action onWin;

    public void Win() 
    {
        if (onWin != null) {
            onWin();
        }
    }

    public void FinishedCharging()
    {
        if (onFinishedCharging != null) {
            onFinishedCharging();
        }
    }

    public void Charge(bool active)
    {
        if (onCharge != null)
        {
            onCharge(active);
        }
    }

    public void CeleiroEnter()
    {
        if (onCeleiroEnter != null)
        {
            onCeleiroEnter();
        }
    }

    public void CeleiroLeave()
    {
        if (onCeleiroLeave != null)
        {
            onCeleiroLeave();
        }
    }

    public void Break(GameObject obj)
    {
        if (onBreak != null)
        {
            onBreak(obj);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeController : MonoBehaviour
{
    private bool charging;
    private bool finished = false;
    private Transform t;
    private Vector3 speed = new Vector3(0, 0.10f, 0);
    public GameObject bar0;

    void Start()
    {
        GameEvents.current.onCharge += onCharge;
        t = bar0.GetComponent<Transform>();
    }

    void onCharge(bool active) {
        charging = active;
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {
       if (charging && t.position.y < 0)
       {
           t.position += Time.deltaTime*speed;
       }
       else if (!charging && t.position.y > -0.75)
       {
           t.position -= Time.deltaTime*speed;
           finished = false;
       }

       if (charging && !finished && t.position.y >= -0.01)
       {
           finished = true;
           GameEvents.current.FinishedCharging();
       }
    }
}

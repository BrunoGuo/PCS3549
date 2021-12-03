using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerTextController : MonoBehaviour
{
    public GameObject player;
    private Timer timer;
    private Text m_text;
    // Start is called before the first frame update
    void Start()
    {
       m_text = GetComponent<Text>(); 
       timer = player.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        m_text.text = "Time: " + timer.timeRemaining.ToString("F2");
    }
}

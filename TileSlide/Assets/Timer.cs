using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text timerTxt;
    public float start;
    public bool stopTime;

    // Start is called before the first frame update
    void Start()
    {
        start = Time.time;
        stopTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopTime)
        {
            float t = Time.time - start;
            string min = ((int) t / 60).ToString();
            string sec = ((int)(t % 60)).ToString("00");

            timerTxt.text = $"{min}:{sec}";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeClock : MonoBehaviour
{

    public GameObject TimeClockDisplay;

    public int hour;
    public int minut;

    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
        hour = System.DateTime.Now.Hour;
        minut = System.DateTime.Now.Minute;
        TimeClockDisplay.GetComponent<Text>().text = "Time: "+hour.ToString("00") + ":" + minut.ToString("00");
      
    }
}

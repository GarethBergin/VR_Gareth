using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class analogClock : MonoBehaviour
{
    [SerializeField]
    private Transform _hourHand;

    [SerializeField]
    private Transform _minuteHand;

    [SerializeField]
    private Transform _secondHand;

    private int _previousSeconds;
    private int _timeInSeconds;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ConverTimeToSeconds();
        RotateClockHands();
    }

    private int ConverTimeToSeconds()
    {
        int currentSeconds = DateTime.Now.Second;
        int currentMinute = DateTime.Now.Minute;
        int currentHour = DateTime.Now.Hour;

        if(currentHour <= 12)
        {
            currentHour -= 12;
        }

        _timeInSeconds = currentSeconds + (currentMinute * 60) + (currentHour * 60 * 60);

        return _timeInSeconds;
    }

    void RotateClockHands()
    {
        float secondhandPerSecond = 360f / 60f;
        float minutehandPerSecond = 360f / (60f * 60f);
        float hourhandPerSecond = 360f / (60f * 60f * 12f);

        if(_timeInSeconds != _previousSeconds)
        {
            _secondHand.localRotation = Quaternion.Euler(_timeInSeconds * secondhandPerSecond, 0, 0);
            _minuteHand.localRotation = Quaternion.Euler(_timeInSeconds * minutehandPerSecond, 0, 0);
            _hourHand.localRotation = Quaternion.Euler(_timeInSeconds * hourhandPerSecond, 0, 0);


        }
    }
}

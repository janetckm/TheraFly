using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;
using System.IO.Ports;
using System;

[RequireComponent(typeof(InputData))]
public class DisplayInputData : MonoBehaviour

{
    public TextMeshProUGUI leftScoreDisplay;
    public TextMeshProUGUI rightScoreDisplay;

    private InputData _inputData;
    private float _leftMaxScore = 0f;
    private float _rightMaxScore = 0f;

    //arduino port
    SerialPort data_stream = new SerialPort("COM10", 9600);
    private bool lightState ;

    private void Start()
    {
        _inputData = GetComponent<InputData>();
        data_stream.Open();
        
    }

    //arduino: turn on led
    public void onLed()
    {
        data_stream.Write("A");
        lightState = true;
        
    }

    //arduino: turn on off
    public void offLed()
    {
        data_stream.Write("off");
        lightState = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 leftVelocity))
        {
            _leftMaxScore = Mathf.Max(leftVelocity.magnitude, _leftMaxScore);
            leftScoreDisplay.text = _leftMaxScore.ToString("F2");
            onLed();
            Debug.Log(leftVelocity.magnitude);

        }
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 rightVelocity))
        {
            _rightMaxScore = Mathf.Max(rightVelocity.magnitude, _rightMaxScore);
            rightScoreDisplay.text = _rightMaxScore.ToString("F2");

        }
    }

    
}

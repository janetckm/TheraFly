using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Script_arduinoTest : MonoBehaviour
{

    SerialPort data_stream = new SerialPort("COM10", 9600);
    private bool lightState = false;

    public void onLed()
    {
        if (data_stream.IsOpen == false)
        {
            data_stream.Open();
        }
        data_stream.Write("A");
        lightState = true;
    }

    
    public void offLed()
    {
        if (data_stream.IsOpen == false)
        {
            data_stream.Open();
        }
        data_stream.Write("off");
        lightState = false;
    }

}

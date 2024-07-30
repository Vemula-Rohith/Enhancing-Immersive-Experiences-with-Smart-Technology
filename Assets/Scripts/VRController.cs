using UnityEngine;
using System.IO.Ports;
using Unity.VisualScripting;

public class VRController : MonoBehaviour
{
    SerialPort serialPort;
    string portName = "COM8"; // Adjust this to match your Arduino's port

    void Start()
    {
        serialPort = new SerialPort(portName, 9600);
        if (!serialPort.IsOpen)
        {
            serialPort.Open(); // Open the serial port if it's not already open
        }

        // Turn on the light immediately when the script is enabled
        TurnOnLight();
    }

    void TurnOnLight()
    {
        if (!serialPort.IsOpen)
        {
            Debug.LogWarning("Serial port is not open");
            return;
        }

        serialPort.Write("1"); // Send command to turn on the light
        Debug.Log("Turning on the light in VR");
        
    }

    void OnDisable() {
        if (!serialPort.IsOpen)
        {
            Debug.LogWarning("Serial port is not open");
            return;
        }

        serialPort.Write("0"); // Send command to turn off the light
        Debug.Log("Turning off the light in VR");
    }

    void OnDestroy()
    {
        if (serialPort.IsOpen)
        {
            serialPort.Close(); // Close the serial port when the object is destroyed
        }
    }
}

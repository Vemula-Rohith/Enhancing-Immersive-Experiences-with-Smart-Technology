using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    public new Light light;
    GameObject presser;
    
    bool isPressed;
    private bool isLightOn = false;

    void Start()
    {
        isPressed = false;
        light.enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Collision");
        if (isPressed)
        {
            Debug.Log("is pressed");
            button.transform.position = new Vector3(20f,0,0);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject == presser)
        {
        button.transform.position = new Vector3(0,0,0);
        onRelease.Invoke();
        isPressed = false;
        }
    }

    public void SpawnLight()
    {
        Debug.Log("Hello");
        isLightOn = !isLightOn;
        light.enabled = isLightOn;
    }
}

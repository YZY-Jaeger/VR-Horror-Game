using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Flashlight : MonoBehaviour
{
    public Material lens;
    public bool flashlight_on;
    private Light _light;
    private AudioSource _audioSource;
    public float flashlight_battery;
    void Start()
    {
        flashlight_battery = 30.0f;//init value of battery
        flashlight_on = false;//set flag
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(
                x => LightSwitch()
        ) ;//default is trigger button


        _light = GetComponentInChildren<Light>();
        _light.enabled = false;//default is off
        _audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (flashlight_on)
        {
            flashlight_battery -= Time.deltaTime;

            if (flashlight_battery <= 10)
            {//low
                Debug.Log("flashlight battery low!");
                if (flashlight_battery <= 0) { LightOff(); flashlight_on = false; Debug.Log("flashlight battery died!"); }//died, turn off
                else { _light.intensity = 2.0f; }//low light

            }
            else { _light.intensity = 100.0f; }//normal light
        }


    }

    public void LightSwitch() { 
        if (flashlight_on) {
            flashlight_on = false;
            LightOff();
        }
        else
        {
            flashlight_on = true;
            LightOn();
        }
    
    
    }
    public void LightOn()
    {
        _audioSource.Play();
        lens.EnableKeyword("_EMISSION");
        _light.enabled = true;
        //flashlight_on = true;//set flag
    }

    public void LightOff()
    {
        _audioSource.Play();
        lens.DisableKeyword("_EMISSION");
        _light.enabled = false;
        //flashlight_on = false;//set flag

    }

    public void charge10()
    {
        _audioSource.Play();
        flashlight_battery += 10;//charge by 10
        Debug.Log("After charging the battery is: "+ flashlight_battery);
    }

}

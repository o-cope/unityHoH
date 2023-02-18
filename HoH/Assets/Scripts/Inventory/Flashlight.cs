using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flashlight : MonoBehaviour
{
    #region Parametres

    [Header("Flashlight")]
    [SerializeField] private GameObject flashlight; //assigned in inspector. refers to light

    [Header("Flashlight noises")]
    [SerializeField] private AudioSource turnOn;
    [SerializeField] private AudioSource turnOff; //audio for the flashlight

    [Header("Bools")]
    [SerializeField] private bool flashlightOn;
    [SerializeField] public bool canUseFlashlight;    //checks if the flashlight is on, and used to reference the ability to use the flashlight from other scripts

    #endregion


    private void Start()
    {
        flashlightOn = false;
        flashlight.SetActive(false); //when starting, the flashlight is disabled
    }

    private void Update()
    {
        if (canUseFlashlight) //if they can use the flashlight
        {
            FlashlightUse(); //flashlight function
        }
    }


    #region Functions

    private void FlashlightUse()
    {
        if (!flashlightOn && Input.GetButtonDown("F")) //if the flashlight is not on and the button is pressed
        {
            flashlight.SetActive(true);
            turnOn.Play();
            flashlightOn = true; //turns on the flashlight and plays audio
        }
        else if (flashlightOn && Input.GetButtonDown("F")) //if the flashlight is on and the button is pressed
        {
            flashlight.SetActive(false); 
            turnOff.Play();
            flashlightOn = false; //turns off the flashlight and plays audio 
        }
    }


    #endregion





}
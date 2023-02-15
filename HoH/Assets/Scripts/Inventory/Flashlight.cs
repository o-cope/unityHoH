using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flashlight : MonoBehaviour
{
    #region Parametres

    [Header("Flashlight")]
    [SerializeField] private GameObject flashlight;

    [Header("Flashlight noises")]
    [SerializeField] private AudioSource turnOn;
    [SerializeField] private AudioSource turnOff;

    [Header("Bools")]
    [SerializeField] private bool flashlightOn;
    [SerializeField] private bool canUseFlashlight;    

    #endregion


    private void Start()
    {
        flashlightOn = false;
        flashlight.SetActive(false);
    }

    private void Update()
    {
        if (canUseFlashlight)
        {
            FlashlightUse();
        }
    }


    #region Functions

    private void FlashlightUse()
    {
        if (!flashlightOn && Input.GetButtonDown("F"))
        {
            flashlight.SetActive(true);
            turnOn.Play();
            flashlightOn = true;
        }
        else if (flashlightOn && Input.GetButtonDown("F"))
        {
            flashlight.SetActive(false);
            turnOff.Play();
            flashlightOn = false;
        }
    }


    #endregion





}
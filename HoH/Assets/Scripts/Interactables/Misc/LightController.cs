using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : Interactable
{
    #region Parametres
    [Header("Light switch states")]
    [SerializeField] private GameObject lightSwitchUp;
    [SerializeField] private GameObject lightSwitchDown; //different light switch states

    [Header("Light")]
    [SerializeField] private GameObject affectedLight; //light game obj

    [Header("Audio")]
    [SerializeField] private AudioSource lightSwitch; //audio for light click
    #endregion

    private void Awake()
    {
        lightSwitchUp.SetActive(false);
        lightSwitchDown.SetActive(true);
        affectedLight.SetActive(false); //ensures that when the light game starts, the light is turned off
    }


    protected override void Interact()
    {
        LightSwitch();
    }

    #region Functions

    private void LightSwitch()
    {
        if (lightSwitchUp.activeInHierarchy) //acts based on what light switch is enabled
        {
            lightSwitchUp.SetActive(false);
            lightSwitchDown.SetActive(true);
            lightSwitch.Play();
            affectedLight.SetActive(false); //if the up switch is enabled and interacted with, disables up light switch and enables down light switch.
        } //turns off light and plays audio
        else if (lightSwitchDown.activeInHierarchy)
        {
            lightSwitchUp.SetActive(true);
            lightSwitchDown.SetActive(false);
            lightSwitch.Play();
            affectedLight.SetActive(true); //opposite of above, light switch up enabled and disables down. Light is on and audio plays.
        }
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : Interactable
{
    #region Parametres
    [Header("Light switch states")]
    [SerializeField] private GameObject lightSwitchUp;
    [SerializeField] private GameObject lightSwitchDown;

    [Header("Light")]
    [SerializeField] private GameObject affectedLight;

    [Header("Audio")]
    [SerializeField] private AudioSource lightSwitch;
    #endregion

    private void Awake()
    {
        lightSwitchUp.SetActive(false);
        lightSwitchDown.SetActive(true);
        affectedLight.SetActive(false);
    }


    protected override void Interact()
    {
        LightSwitch();
    }

    #region Functions

    private void LightSwitch()
    {
        if (lightSwitchUp.activeInHierarchy)
        {
            lightSwitchUp.SetActive(false);
            lightSwitchDown.SetActive(true);
            lightSwitch.Play();
            affectedLight.SetActive(false);
        }
        else if (lightSwitchDown.activeInHierarchy)
        {
            lightSwitchUp.SetActive(true);
            lightSwitchDown.SetActive(false);
            lightSwitch.Play();
            affectedLight.SetActive(true);
        }
    }
    #endregion
}

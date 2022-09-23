using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [Header("Flashlight")]
    [SerializeField] private GameObject flashlight;

    [Header("Flashlight noises")]
    [SerializeField] private AudioSource turnOn;
    [SerializeField] private AudioSource turnOff;

    [Header("On and off")]
    [SerializeField] private bool flashlightOn;
    [SerializeField] private bool flashlightOff;


    private void Start()
    {
        flashlightOff = true;
        flashlight.SetActive(false);
    }

    private void Update()
    {
        if (flashlightOff && Input.GetButtonDown("F"))
        {
            flashlight.SetActive(true);
            turnOn.Play();
            flashlightOff = false;
            flashlightOn = true;
        }
        else if (flashlightOn && Input.GetButtonDown("F"))
        {
            flashlight.SetActive(false);
            turnOff.Play();
            flashlightOff = true;
            flashlightOn = false;
        }
    }







}
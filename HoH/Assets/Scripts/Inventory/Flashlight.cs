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

    [Header("On")]
    [SerializeField] private bool flashlightOn;


    private void Start()
    {
        flashlightOn = false;
        flashlight.SetActive(false);
    }

    private void Update()
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







}
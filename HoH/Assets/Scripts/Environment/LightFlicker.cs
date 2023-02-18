using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    #region Parametres
    [Header("game Objects")]
    [SerializeField] private Light lightOb;

    [Header("Audio")]
    [SerializeField] private AudioSource lightFlickerSound; 

    [Header("Flicker Time")]
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime; //assigned in the inspector. min time and max time refer too how long the light can be enabled for

    private float timer; //internal timer to keep track
    #endregion

    private void Start()
    {
        timer = Random.Range(minTime, maxTime); //finds random value and assigns to timer
    }

    private void Update()
    {
        LightsFlickering(); //calls function
    }

    #region Functions
    private void LightsFlickering()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; //if timer is greater than 0, timer decreases
        }
        if (timer <= 0)
        {
            lightOb.enabled = !lightOb.enabled;
            timer = Random.Range(minTime, maxTime);
            lightFlickerSound.Play(); //if timer is less than or equal to zero, the light switches state and the timer resets, plays audio
        }
    }


    #endregion

}

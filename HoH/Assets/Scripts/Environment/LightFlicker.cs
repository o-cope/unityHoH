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
    [SerializeField] private float maxTime;

    private float timer;
    #endregion

    private void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }

    private void Update()
    {
        LightsFlickering();
    }

    #region Functions
    private void LightsFlickering()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            lightOb.enabled = !lightOb.enabled;
            timer = Random.Range(minTime, maxTime);
            lightFlickerSound.Play();
        }
    }


    #endregion

}

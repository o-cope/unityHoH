using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : Interactable
{
    #region Parametres
    [Header("Game Object")]
    [SerializeField] private GameObject candleInv;
    [Header("Audio")]
    [SerializeField] private AudioSource pickUpSFX;
    #endregion

    protected override void Interact()
    {
        PickUpCandle();
    }

    #region Functions
    private void PickUpCandle()
    {
        gameObject.SetActive(false);
        pickUpSFX.Play();
        candleInv.SetActive(true);
    }

    #endregion
}


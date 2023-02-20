using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : Interactable
{
    #region Parametres
    [Header("Game Object")]
    [SerializeField] private GameObject candleInv;

    #endregion

    protected override void Interact()
    {
        PickUpCandle();
    }

    #region Functions
    private void PickUpCandle()
    {
        gameObject.SetActive(false);
        candleInv.SetActive(true);
    }

    #endregion
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookControllerIce : Interactable
{
    #region Parametres
    [Header("Books In Inventory")]
    [SerializeField] private GameObject iceBookInventory;
    [Header("Audio")]
    [SerializeField] private AudioSource pickUpAudio;
    #endregion

    protected override void Interact()
    {
        PickUpBook();
    }

    #region Functions

    private void PickUpBook()
    {
        gameObject.SetActive(false);
        pickUpAudio.Play();
        iceBookInventory.SetActive(true);
    }    

    #endregion
}
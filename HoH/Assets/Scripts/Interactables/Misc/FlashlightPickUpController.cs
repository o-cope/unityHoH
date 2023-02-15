using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPickUpController : Interactable
{
    #region Parametres
    [Header("Player Object")]
    [SerializeField] private GameObject player;
    
    
    private Flashlight flashlight;


    #endregion

    private void Start()
    {
        flashlight = player.GetComponent<Flashlight>();
    }

    protected override void Interact()
    {
        PickUp();
    }

    #region Functions

    private void PickUp()
    {
        flashlight.canUseFlashlight = true;
    }

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashlightPickUpController : Interactable
{
    #region Parametres
    [Header("Player Object")]
    [SerializeField] private GameObject player;

    [Header("Flashlight")]
    [SerializeField] private GameObject flashlightObj;

    [Header("Audio")]
    [SerializeField] private AudioSource pickUpFlashlight;
    
    [Header("Wall")]
    [SerializeField] private GameObject[] walls = new GameObject[2];

    [Header("Canvas")]
    [SerializeField] private Canvas canvasFlashlight;
    [SerializeField] private Canvas canvasEnableText; //Assigns variables

    private Flashlight flashlight; //References script


    #endregion

    private void Start()
    {
        flashlight = player.GetComponent<Flashlight>();
    }

    protected override void Interact()
    {
        PickUp(); //When player interacts
    }

    #region Functions

    private void PickUp()
    {
        pickUpFlashlight.Play(); //Plays Audio
        flashlightObj.SetActive(false); //Disables Flashlight Object in game
        flashlight.canUseFlashlight = true; //Allows player to use flashlight

        canvasFlashlight.enabled = false; //Disables text
        canvasEnableText.gameObject.SetActive(true); //Enables other text

        Destroy(GetComponent<BoxCollider>()); //Stops the player from being able to interact with nonexistent flashlight
        Destroy(walls[0]);
        Destroy(walls[1]);   //Destroys obstructions allowing player to play
    }



    #endregion
}

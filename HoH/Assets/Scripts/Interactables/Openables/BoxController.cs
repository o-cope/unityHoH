using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : Interactable
{
    #region Parametres
    [Header("gameObjects")]
    [SerializeField] private GameObject keyRequired; //references key in inspector

    [Header("Audio")]
    [SerializeField] private AudioSource openSound;
    [SerializeField] private AudioSource lockedSound; //assigned in inspector

    private Animator boxAnim;
    private bool open = false; //internal variables to keep track
    #endregion
    
    private void Awake()
    {
        boxAnim = gameObject.GetComponent<Animator>(); //gets the animation for the box
    }
    protected override void Interact()
    {
        Box();
    }

    #region Functions

    private void Box()
    {
        if (keyRequired.activeInHierarchy && !open) //if the key is active in the players inventory and the box is not open
        {
            boxAnim.Play("boxOpen", 0, 0.0f); //plays box open animation
            keyRequired.SetActive(false); //disables key again
            openSound.Play(); //plays audio
            open = true; //sets open to true
        }
        else if (!keyRequired.activeInHierarchy && !open) //if opposite but key not active
        {
            lockedSound.Play(); //play locked sound
        }
    }

    #endregion
}

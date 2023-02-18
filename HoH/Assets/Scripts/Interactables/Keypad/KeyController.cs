using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : Interactable
{
    #region Parametres
    [Header("Key Objects")]
    [SerializeField] private GameObject keyOb;
    [SerializeField] private GameObject invOb; //assigned in inspector. keyObj is the key, inv Obj refers to the key being in the players inventory

    [Header("Audio")]
    [SerializeField] private AudioSource keySound;
    #endregion
    protected override void Interact()
    {
        Key();
    }

    #region Functions
    
    private void Key()
    {
        keyOb.SetActive(false);
        keySound.Play();
        invOb.SetActive(true); //disables the key on the floor and plays audio. In inventory, new obj is now enabled and referenced later on
    }

    #endregion
}

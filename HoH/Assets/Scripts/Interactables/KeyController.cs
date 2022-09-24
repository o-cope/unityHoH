using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : Interactable
{
    #region Parametres
    [Header("Key Objects")]
    [SerializeField] private GameObject keyOb;
    [SerializeField] private GameObject invOb;

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
        invOb.SetActive(true);
    }

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : Interactable
{

    [Header("Key Objects")]
    [SerializeField] private GameObject keyOb;
    [SerializeField] private GameObject invOb;

    [Header("Audio")]
    [SerializeField] private AudioSource keySound;

    protected override void Interact()
    {
        keyOb.SetActive(false);
        keySound.Play();
        invOb.SetActive(true);
    }
}

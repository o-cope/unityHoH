using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : Interactable
{

    #region Parametres 
    [Header("gameObjects")]
    [SerializeField] private GameObject lockOb = null;
    [SerializeField] private GameObject keyOb = null; //assigned in inspector
    
    [Header("Audio")]
    [SerializeField] private AudioSource openSound;
    [SerializeField] private AudioSource closeSound;
    [SerializeField] private AudioSource lockedSound;
    [SerializeField] private AudioSource unlockedSound; //audio options

    [Header("Lock settings")]
    [SerializeField] private bool locked;
    [SerializeField] private bool unlocked; //checks if door is locked or unlocked
    
    
    private Animator doorAnim;
    private bool isAnimating = false;
    private bool doorOpen = false; //internal variables to help organise things
    #endregion
    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>(); //gets animation component before starting
    }

    private void Update()
    {
        CheckLock(); //checks if it is locked every frame
    }

    protected override void Interact()
    {
        Door(); //calls door function
    }

    #region Functions

    private void Door()
    {
        if (keyOb.activeInHierarchy) //if the key is there
        {
            unlockedSound.Play(); //play audio
            locked = false; // not locked 
            keyOb.SetActive(false); //disables key object
            StartCoroutine(unlockDoor()); //begins coroutine
        }
        if (!doorOpen && !isAnimating && unlocked) //if door is not open, not animating and unlocked
        {
            doorAnim.Play("doorOpens", 0, 0.0f); //play animation open
            openSound.Play();
            doorOpen = true; //audio door open and door open is now true
        }
        else if (doorOpen && !isAnimating && unlocked) //if door open is true, is not animating, and unlocked
        {
            doorAnim.Play("doorClose", 0, 0.0f); // play door close animation
            closeSound.Play();
            doorOpen = false; //door open is false and plays close sound
        }
        if (locked)
        {
            lockedSound.Play(); //if the door is locked and none of the above is true, play locked sound
        }
    }

    private void CheckLock()
    {
        if (lockOb.activeInHierarchy)
        {
            locked = true;
            unlocked = false; //if the locke object is active in hierarchy, the door is locked
        }
        else
        {
            locked = false;
            unlocked = true; //else, it is unlocked
        }
    }

    IEnumerator unlockDoor()
    {
        yield return new WaitForSeconds(0.05f);
        {
            unlocked = true;
            lockOb.SetActive(false); //disables lock object and sets unlocked to true
        }

    }


    private void DisableInteract()
    {
        isAnimating = true;
    }
    private void EnableInteract()
    {
        isAnimating = false; //two functions that work in the animation. These prevent the doors from being spammed when animating and breaking them
    }

    #endregion

}

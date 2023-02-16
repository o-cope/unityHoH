using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDoorController : Interactable
{

    #region Parametres 
    [Header("gameObjects")]
    [SerializeField] private GameObject lockOb = null;
    [SerializeField] private GameObject keyOb = null;

    [Header("Audio")]
    [SerializeField] private AudioSource openSound;
    [SerializeField] private AudioSource closeSound;
    [SerializeField] private AudioSource lockedSound;
    [SerializeField] private AudioSource unlockedSound;

    [Header("Lock settings")]
    [SerializeField] private bool locked;
    [SerializeField] private bool unlocked;


    private Animator doorAnim;
    private bool isAnimating = false;
    private bool doorOpen = false;
    #endregion
    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        CheckLock();
    }

    protected override void Interact()
    {
        Door();
    }

    #region Functions

    private void Door()
    {
        if (keyOb.activeInHierarchy)
        {
            unlockedSound.Play();
            locked = false;
            keyOb.SetActive(false);
            StartCoroutine(unlockDoor());
        }
        if (!doorOpen && !isAnimating && unlocked)
        {
            doorAnim.Play("dungeonDoorOpens", 0, 0.0f);
            openSound.Play();
            doorOpen = true;
        }
        else if (doorOpen && !isAnimating && unlocked)
        {
            doorAnim.Play("dungeonDoorCloses", 0, 0.0f);
            closeSound.Play();
            doorOpen = false;
        }
        if (locked)
        {
            lockedSound.Play();
        }
    }

    private void CheckLock()
    {
        if (lockOb.activeInHierarchy)
        {
            locked = true;
            unlocked = false;
        }
        else
        {
            locked = false;
            unlocked = true;
        }
    }

    IEnumerator unlockDoor()
    {
        yield return new WaitForSeconds(0.05f);
        {
            unlocked = true;
            lockOb.SetActive(false);
        }

    }


    private void DisableInteract()
    {
        isAnimating = true;
    }
    private void EnableInteract()
    {
        isAnimating = false;
    }

    #endregion

}


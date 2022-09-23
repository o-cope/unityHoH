using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AdvancedDoors : MonoBehaviour
{
    [Header("Lock settings")]
    [SerializeField] private bool locked;
    [SerializeField] private bool unlocked;

    [Header("Animator")]
    [SerializeField] private Animator door;

    [Header("Game Objects")]
    [SerializeField] private GameObject lockOB;
    [SerializeField] private GameObject keyOB;
    [SerializeField] private GameObject openText;
    [SerializeField] private GameObject closeText;
    [SerializeField] private GameObject lockedText;
    [SerializeField] private BoxCollider doorCollider;

    [Header("Audio")]
    [SerializeField] private AudioSource openSound;
    [SerializeField] private AudioSource closeSound;
    [SerializeField] private AudioSource lockedSound;
    [SerializeField] private AudioSource unlockedSound;

    private bool inReach;
    private bool doorisOpen;
    private bool doorisClosed;
    private bool isAnimating = false;

    private void OnTriggerEnter(Collider reachTool)
    {
        if (reachTool.gameObject.tag == "Reach" && doorisClosed)
        {
            inReach = true;
            openText.SetActive(true);
        }
        if (reachTool.gameObject.tag == "Reach" && doorisOpen)
        {
            inReach = true;
            closeText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider reachTool)
    {
        if (reachTool.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            closeText.SetActive(false);
            lockedText.SetActive(false);
        }
    }

    private void Start()
    {
        inReach = false;
        doorisClosed = true;
        doorisOpen = false;
        closeText.SetActive(false);
        openText.SetActive(false);

        doorCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (lockOB.activeInHierarchy)
        {
            locked = true;
            unlocked = false;
        }
        else
        {
            locked = false;
            unlocked = true;   
        }

        if (inReach && keyOB.activeInHierarchy && Input.GetButtonDown("Interact"))
        {
            unlockedSound.Play();
            locked = false;
            keyOB.SetActive(false);
            StartCoroutine(unlockDoor());
        }

        if (inReach && doorisClosed && unlocked && Input.GetButtonDown("Interact") && isAnimating == false)
        {
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
            openText.SetActive(false);
            openSound.Play();
            doorisOpen = true;
            doorisClosed = false;
            
        }

        else if (inReach && doorisOpen && unlocked && Input.GetButtonDown("Interact") && isAnimating == false)
        {
            door.SetBool("Open", false);
            door.SetBool("Closed", true);
            closeText.SetActive(false);
            closeSound.Play();
            doorisOpen = false;
            doorisClosed = true;
        }


        if (inReach && locked && Input.GetButtonDown("Interact"))
        {
            openText.SetActive(false);
            lockedText.SetActive(true);
            lockedSound.Play();
        }




    }

    IEnumerator unlockDoor()
    {
        yield return new WaitForSeconds(0.05f);
        {
            unlocked = true;
            lockOB.SetActive(false);
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
}

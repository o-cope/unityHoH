using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDoor : MonoBehaviour
{


    [Header("Raycast Distance")]
    [SerializeField] private int raycastDist;

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

    [Header("Audio")]
    [SerializeField] private AudioSource openSound;
    [SerializeField] private AudioSource closeSound;
    [SerializeField] private AudioSource lockedSound;
    [SerializeField] private AudioSource unlockedSound;

    private bool inReach;
    private bool doorisOpen;
    private bool doorisClosed;
    private bool isAnimating = false;



    [SerializeField] private Vector3 collision = Vector3.zero;


    private void Start()
    {
        inReach = false;
        doorisClosed = true;
        doorisOpen = false;
        closeText.SetActive(false);
        openText.SetActive(false);

    }

    private void Update()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDist))
        {
            collision = hit.point;

            if (hit.transform.gameObject.CompareTag("DoorHinge"))
            {
                Debug.Log("Door Hinge");
            }

            if (hit.transform.gameObject.CompareTag("DoorHinge") && doorisClosed)
            {
                inReach = true;
                openText.SetActive(true);
            }
            else if (hit.transform.gameObject.CompareTag("DoorHinge") && doorisOpen)
            {
                inReach = true;
                closeText.SetActive(true);
            }
            else if (!hit.transform.gameObject.CompareTag("DoorHinge"))
            {
                inReach = false;
                openText.SetActive(false);
                closeText.SetActive(false);
                lockedText.SetActive(false);
            }
        }



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


    private void OnDrawGizmos()
    {
        Update();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(collision, 0.2f);
    }


}


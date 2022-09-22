using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator boxOb;

    [Header("Game Object references")]
    [SerializeField] private GameObject keyObNeeded;
    [SerializeField] private GameObject openText;
    [SerializeField] private GameObject keyMissingText;

    [Header("Audio")]
    [SerializeField] private AudioSource openSound;

    private bool inReach;
    private bool isOpen;

    private void Start()
    {
        inReach = false;
        openText.SetActive(false);
        keyMissingText.SetActive(false);
    }

    private void OnTriggerEnter(Collider reach)
    {
        if (reach.gameObject.CompareTag("Reach"))
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider reach)
    {
        if (reach.gameObject.CompareTag("Reach"))
        {
            inReach = false;
            openText.SetActive(false);
            keyMissingText.SetActive(false);
        }
    }

    private void Update()
    {
        if (keyObNeeded.activeInHierarchy == true && inReach && Input.GetButtonDown("Interact"))
        {
            keyObNeeded.SetActive(false);
            openSound.Play();
            boxOb.SetBool("open", true);     
            openText.SetActive(false);
            keyMissingText.SetActive(false);
            isOpen = true;
        }
        else if (keyObNeeded.activeInHierarchy == false && inReach && Input.GetButtonDown("Interact"))
        {
            openText.SetActive(false);
            keyMissingText.SetActive(true);
        }

        if (isOpen)
        {
            boxOb.GetComponent<BoxCollider>().enabled = false;
            boxOb.GetComponent<Box>().enabled = false;
        }
    }



}

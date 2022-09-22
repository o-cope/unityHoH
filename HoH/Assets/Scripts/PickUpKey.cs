using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    [Header("Key Objects")]
    [SerializeField] private GameObject keyOb;
    [SerializeField] private GameObject invOb;

    [Header("Text")]
    [SerializeField] private GameObject pickUpText;

    [Header("Audio")]
    [SerializeField] private AudioSource keySound;

    private bool inReach;

    private void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        invOb.SetActive(false);
    }

    private void OnTriggerEnter(Collider reach)
    {
        if (reach.gameObject.CompareTag("Reach"))
        {
            inReach = true;
            pickUpText.SetActive(true);        
        }
    }

    private void OnTriggerExit(Collider reach)
    {
        if (reach.gameObject.CompareTag("Reach"))
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    private void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            keyOb.SetActive(false);
            keySound.Play();
            invOb.SetActive(true);
            pickUpText.SetActive(false);
        }
    }


}

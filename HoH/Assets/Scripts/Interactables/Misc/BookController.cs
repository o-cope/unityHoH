using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : Interactable
{
    #region Parametres
    [Header("Books In Inventory")]
    [SerializeField] private GameObject[] booksInInventory = new GameObject[3];
    [Header("Audio")]
    [SerializeField] private AudioSource pickUpAudio;
    #endregion

    protected override void Interact()
    {
        PickUpBook();
    }

    #region Functions

    private void PickUpBook()
    {
        gameObject.SetActive(false);
        pickUpAudio.Play();

        for (int i = 0; i < booksInInventory.Length; i++)
        {
            if (booksInInventory[i] != null && !booksInInventory[i].activeInHierarchy)
            {
                booksInInventory[i].SetActive(true);
                break;
            }
        }    
    }

    #endregion
}

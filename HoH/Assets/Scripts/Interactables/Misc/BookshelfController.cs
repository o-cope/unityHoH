using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookshelfController : Interactable
{
    #region Parametres
    
    [Header("Books")]
    [SerializeField] private GameObject[] booksInInventory = new GameObject[4];
    [SerializeField] private GameObject[] booksForShelf = new GameObject[4];
    [Header("CanvasText")]
    [SerializeField] private TextMeshProUGUI booksText;
    [Header("Grate")]
    [SerializeField] private GameObject grate;
    [Header("Audio")]
    [SerializeField] private AudioSource allBooksGathered;
    [SerializeField] private AudioSource grateOpen;


    private Animator grateAnim;
    #endregion

    private void Start()
    {
        grateAnim = grate.GetComponent<Animator>();
    }


    protected override void Interact()
    {
        CheckBooks();
    }


    #region Functions
    private void CheckBooks()
    {
        if (CheckArray())
        {
            foreach (GameObject book in booksForShelf)
            {
                book.SetActive(true);
            }
            StartCoroutine(openGrates());
        }
        else
        {
            Debug.Log("CHECK BOOKS FALSE");
            booksText.enabled = true;
            StartCoroutine(disableBookText());
        }
    }


    private bool CheckArray()
    {
        for (int i = 0; i < booksInInventory.Length; i++)
        {
            if (booksInInventory[i].activeInHierarchy == false)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator openGrates()
    {
        yield return new WaitForSecondsRealtime(1f);
        grateAnim.Play("gratesOpen");
    }

    IEnumerator disableBookText()
    {
        yield return new WaitForSecondsRealtime(5f);
        booksText.enabled = false;
    }

    #endregion

}

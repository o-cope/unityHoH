using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IceController : Interactable
{
    #region Parametres
    [Header("Game Objects")]
    [SerializeField] private GameObject candle;
    [SerializeField] private GameObject invCandle;
    [SerializeField] private GameObject iceCandle;
    [SerializeField] private GameObject book;
    [SerializeField] private GameObject iceCube;
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI getCandleText;

    private bool firstInteract = true;
    #endregion


    protected override void Interact()
    {
        MeltIce();
    }

    #region Functions
    private void MeltIce()
    {
        if (firstInteract)
        {
            getCandleText.enabled = true;
            candle.GetComponent<BoxCollider>().enabled = true;
            firstInteract = false;
            StartCoroutine(disableText());
        }
        if (!firstInteract && invCandle.activeInHierarchy)
        {
            iceCandle.SetActive(true);
            StartCoroutine(deleteIce());

        }
        
    }

    IEnumerator disableText()
    {
        yield return new WaitForSecondsRealtime(5f);
        getCandleText.enabled = false;
    }

    IEnumerator deleteIce()
    {
        yield return new WaitForSecondsRealtime(3f);
        iceCube.SetActive(false);
        book.GetComponent<BoxCollider>().enabled = true;
    }
    #endregion

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaperKeypad : MonoBehaviour
{
    #region Parametres
    [Header("Password")]
    [SerializeField] private KeypadController keypadController;
    [SerializeField] private GameObject keypadObject;
    [Header("Text object")]
    [SerializeField] private TMP_Text numText; //all assigned in inspector

    #endregion

    private void Awake()
    {
        keypadController = keypadObject.GetComponent<KeypadController>(); //gets keypad script from keypad
    }

    private void Start()
    {
        TextOnPaper();
    }
    #region Functions
    private void TextOnPaper()
    {
        numText.text = keypadController.password; //sets the text on the paper to be the password on the keypad
    }
    #endregion



}

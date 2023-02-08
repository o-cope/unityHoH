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
    [SerializeField] private TMP_Text numText;

    #endregion

    private void Awake()
    {
        keypadController = keypadObject.GetComponent<KeypadController>();
    }

    private void Start()
    {
        TextOnPaper();
    }
    #region Functions
    private void TextOnPaper()
    {
        numText.text = keypadController.password;
    }
    #endregion



}

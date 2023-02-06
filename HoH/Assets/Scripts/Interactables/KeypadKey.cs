using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadKey : Interactable 
{
    #region Parametres
    [SerializeField] private string key;
    #endregion

    protected override void Interact() //inherited function that is used for every object that is interactable
    {
        SendKey();
    }

    #region Functions
    private void SendKey()
    {
        this.transform.GetComponentInParent<KeypadController>().PasswordEntry(key); //sends the button press to the KeyPad Controller script.
    }

    #endregion
}

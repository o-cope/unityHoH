using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private bool isInteractable;

    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        //template
    }

}
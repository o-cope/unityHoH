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
    protected abstract void Interact(); //abstract class that works by ensuring that all child classes inherit the interact fucntion to interact
}
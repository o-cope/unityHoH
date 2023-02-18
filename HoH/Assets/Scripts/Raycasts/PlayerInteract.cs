using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    #region Parametres
    [Header("Raycast Length")]
    [SerializeField] private float distance = 3f;
    [Header("Interact Layer")]
    [SerializeField] private LayerMask mask;
    [Header("Interact Button")]
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [Header("Crosshair")]
    [SerializeField] private Image crosshair; //assigned in the inspector

    private Interactable currentInteractable;
    private Camera cam;


    #endregion
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); //finds camera object
    }
    void Update()
    {
        CheckInteraction();
        OnFocus();
    }


    #region Functions
    private void CheckInteraction()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward); //create a new ray pointing forward from the cameras position
        Debug.DrawRay(ray.origin, ray.direction * distance); //draw a debug ray to show the rays direction and length in the scene view
        RaycastHit hitInfo; //create a RaycastHit object to store information about any objects hit by the raycast

        if (Physics.Raycast(ray, out hitInfo, distance, mask)) //if the raycast hits an object on a specific layer and within a certain distance
        {
            if (hitInfo.collider.gameObject.layer == 10 && (!currentInteractable || hitInfo.collider.gameObject.GetInstanceID() != currentInteractable.GetInstanceID())) //if the hit object is on a specific layer and is different from the current interactable object
            {
                hitInfo.collider.TryGetComponent(out currentInteractable); //try to get the interactable component from the hit object and set it as the current interactable

                if (Input.GetKeyDown(interactKey)) //if the player presses the interact key, call the BaseInteract method of the current interactable
                {
                    currentInteractable.BaseInteract();
                }
            }
        }
        else if (currentInteractable) //if the raycast doesnt hit anything or the hit object is out of range
        {
            currentInteractable = null; //set the current interactable to null
        }
    }


    private void OnFocus()
    {
        if (currentInteractable)
        {
            crosshair.enabled = true; //if currentInteractible returns a value, the crosshair shows  
        }
        else
        {
            crosshair.enabled = false; //else it is not there
        }
        
    }
    #endregion




}





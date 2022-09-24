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
    [SerializeField] private Image crosshair;

    private Interactable currentInteractable;
    private Camera cam;


    #endregion
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); 
    }
    void Update()
    {
        CheckInteraction();
        OnFocus();
    }


    #region Functions
    private void CheckInteraction()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.gameObject.layer == 10 && (!currentInteractable || hitInfo.collider.gameObject.GetInstanceID() != currentInteractable.GetInstanceID()))
            {
                hitInfo.collider.TryGetComponent(out currentInteractable);

                if (Input.GetKeyDown(interactKey))
                {
                    currentInteractable.BaseInteract();
                }
            }
        }
        else if (currentInteractable)
        {
            currentInteractable = null;
        }
    }


    private void OnFocus()
    {
        if (currentInteractable)
        {
            crosshair.enabled = true;
        }
        else
        {
            crosshair.enabled = false;
        }
        
    }
    #endregion




}





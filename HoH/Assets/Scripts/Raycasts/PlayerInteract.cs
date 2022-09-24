using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{   
    [Header("Raycast Length")]
    [SerializeField] private float distance = 3f;
    [Header("Interact Layer")]
    [SerializeField] private LayerMask mask;
    [Header("Interact Button")]
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    private Camera cam;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;


        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

                if (Input.GetKeyDown(interactKey))
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}





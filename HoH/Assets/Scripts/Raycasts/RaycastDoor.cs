using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDoor : MonoBehaviour
{
    [Header("Raycast length")]
    [SerializeField] private int rayLength = 3;
    
    [Header("Layer Mask")]
    [SerializeField] private LayerMask layerMaskInteract;

    [Header("Exclusions")]
    [SerializeField] private string excludeLayerName = null;

    private DoorController raycastedObj;

    [Header("Interact Button")]
    [SerializeField] private KeyCode openDoorKey = KeyCode.E;

    private const string interactableTag = "interactiveDoor";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag("interactiveDoor"))
            {
                raycastedObj = hit.collider.gameObject.GetComponent<DoorController>();
            }

            if (Input.GetKeyDown(openDoorKey))
            {
                raycastedObj.PlayDoorAnimation();
            }
        }
    }


}


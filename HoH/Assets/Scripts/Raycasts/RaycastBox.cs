using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBox : MonoBehaviour
{
    [Header("Raycast length")]
    [SerializeField] private int rayLength = 3;

    [Header("Layer Mask")]
    [SerializeField] private LayerMask layerMaskInteract;

    [Header("Exclusions")]
    [SerializeField] private string excludeLayerName = null;

    [Header("Interact Button")]
    [SerializeField] private KeyCode openBox = KeyCode.E;

    private const string interactableTag = "interactiveBox";

    private BoxController raycastedObj;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag("interactiveBox"))
            {
                raycastedObj = hit.collider.gameObject.GetComponent<BoxController>();
            }

            if (Input.GetKeyDown(openBox))
            {
                raycastedObj.PlayBoxAnimation();
            }
        }
    }
}

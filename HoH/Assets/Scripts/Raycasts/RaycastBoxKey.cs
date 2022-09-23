using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBoxKey : MonoBehaviour
{
    [Header("Raycast length")]
    [SerializeField] private int rayLength = 3;

    [Header("Layer Mask")]
    [SerializeField] private LayerMask layerMaskInteract;

    [Header("Exclusions")]
    [SerializeField] private string excludeLayerName = null;

    [Header("Interact Button")]
    [SerializeField] private KeyCode pickUpKey = KeyCode.E;

    [Header("Key Objects")]
    [SerializeField] private GameObject keyOb;
    [SerializeField] private GameObject invOb;

    [Header("Audio")]
    [SerializeField] private AudioSource keySound;

    private const string interactableTag = "interactiveBoxKey";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (Input.GetKeyDown(pickUpKey))
                {
                    keyOb.SetActive(false);
                    keySound.Play();
                    invOb.SetActive(true);
                }
            }
        }
    }

}

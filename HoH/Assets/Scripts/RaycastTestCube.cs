using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTestCube : MonoBehaviour
{
    [Header("Raycast Distance")]
    [SerializeField] private int raycastDist;



    void Update()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDist))
        {
            if (hit.transform.gameObject.CompareTag("Cube") && Input.GetButtonDown("Interact"))
            {
                hit.transform.gameObject.SetActive(false);
                Debug.Log("Hitting Cube");
            }
        }
    }
}

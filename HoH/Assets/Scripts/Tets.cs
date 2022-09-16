using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tets : MonoBehaviour
{
    [SerializeField] private GameObject textDisplay;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            textDisplay.SetActive(true);   
        }
    }

}

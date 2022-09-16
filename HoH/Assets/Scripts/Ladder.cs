using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StarterAssets
{

    public class Ladder : MonoBehaviour
    {
        [SerializeField] private Transform playerController;
        private bool inside = false;
        [SerializeField] private float speed = 3f;
        [SerializeField] private FirstPersonController player;
        [SerializeField] private AudioSource sound;


        private void Start()
        {
            player = GetComponent<FirstPersonController>();
            inside = false;
        }


        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Ladder")
            {
                Debug.Log("TouchingLadderTrue");
                player.enabled = false;
                inside = !inside;
            }
        }

        private void OnTriggerExit(Collider col)
        {
            if (col.gameObject.tag == "Ladder")
            {
                Debug.Log("TouchingLadderTrue");
                player.enabled = true;
                inside = !inside;
            }
        }


        private void Update()
        {
           if (inside == true && Input.GetKey("w"))
            {
                player.transform.position += Vector3.up /
                speed * Time.deltaTime; 
            }


            if (inside == true && Input.GetKey("s"))
            {
                player.transform.position += Vector3.down /
                speed * Time.deltaTime;
            }


            if (inside == true && Input.GetKey("w"))
            {
                sound.enabled = true;
                sound.loop = true;
            }
            else
            {
                sound.enabled = false;
                sound.loop = false;
            }
        }


    }
}
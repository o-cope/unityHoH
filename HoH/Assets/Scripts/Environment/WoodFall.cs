using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodFall : MonoBehaviour
{
    #region Parametres
    [Header("Fall Sections")]
    [SerializeField] private GameObject preFall;
    [SerializeField] private GameObject postFall;
    [Header("Audio")]
    [SerializeField] private AudioSource woodBreakAudio; //all assigned in inspector
    #endregion

    private void OnTriggerEnter(Collider player) //assigns collider variable to player
    {
        if (player.CompareTag("Player")) //checks if player entered the trigger
        {
            Fall(); //runs fall function
            Destroy(gameObject.GetComponent<BoxCollider>()); //destroys the collider preventing the player from playing the audio again and again
            StartCoroutine(DeleteBox()); //deletes box collider that prevents player cheating
        }
    }
    #region Functions

    private void Fall()
    {
        preFall.SetActive(false);
        postFall.SetActive(true); //switches what is enabled

        woodBreakAudio.Play(); //plays audio
    }

    #endregion

    #region Coroutine

    IEnumerator DeleteBox()
    {
        yield return new WaitForSecondsRealtime(3f);
        Destroy(postFall.GetComponent<BoxCollider>()); //waits 3 seconds then deletes collider
    }

    #endregion


}

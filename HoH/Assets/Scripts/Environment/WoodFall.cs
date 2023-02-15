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
    [SerializeField] private AudioSource woodBreakAudio;
    #endregion

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            Fall();
            Destroy(gameObject.GetComponent<BoxCollider>());
            StartCoroutine(DeleteBox());
        }
    }
    #region Functions

    private void Fall()
    {
        preFall.SetActive(false);
        postFall.SetActive(true);

        woodBreakAudio.Play();
    }

    #endregion

    #region Coroutine

    IEnumerator DeleteBox()
    {
        yield return new WaitForSecondsRealtime(3f);
        Destroy(postFall.GetComponent<BoxCollider>());
    }

    #endregion


}

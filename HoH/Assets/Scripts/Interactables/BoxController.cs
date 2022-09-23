using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [Header("gameObjects")]
    [SerializeField] private GameObject keyRequired;

    [Header("Audio")]
    [SerializeField] private AudioSource openSound;
    [SerializeField] private AudioSource lockedSound;

    private Animator boxAnim;
    private bool open = false;

    private void Awake()
    {
        boxAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayBoxAnimation()
    {
        if (keyRequired.activeInHierarchy && !open)
        {
            boxAnim.Play("boxOpen", 0, 0.0f);
            openSound.Play();
            open = true;
        }
        else if (!keyRequired.activeInHierarchy)
        {
            lockedSound.Play();
        }
    }

}

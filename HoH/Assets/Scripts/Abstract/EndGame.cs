using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : Interactable
{
    [SerializeField] private string sceneName;

    protected override void Interact()
    {
        LoadScene(sceneName);
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); //Attached to the red cube. Loads the next scene which is intended to be the next level
    }
}

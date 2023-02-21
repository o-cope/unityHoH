using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
    #region Parametres
    [Header("Password Parametres")]
    [SerializeField] public string password;
    [SerializeField] private int passwordLength;
    [SerializeField] private Text passwordText; //These establish the parametres regarding the password such as how long it can be and the type they are, i.e., "Text"
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField, Tooltip("Hi")] private AudioClip correctSound;
    [SerializeField] private AudioClip wrongSound; //Establishes the audio variables in the game engine inspector.

    [SerializeField] private GameObject grate;
    [SerializeField] private GameObject endCube;
    private Animator grateAnim;

    #endregion

    private void Awake()
    {
        int passwordRng = Random.Range(1000, 10000);
        password = passwordRng.ToString(); //Randomises password
    }

    private void Start()
    {
        passwordText.text = ""; //Clears the text on start.
        grateAnim = grate.GetComponent<Animator>();

    }

    #region Functions
    public void PasswordEntry(string inputted) //Public function so it can be accessed anywhere
    {
        if (inputted == "Clear")
        {
            Clear();
            return;
        }
        else if (inputted == "Enter")
        {
            Enter();
            return;
        } //These if statements are for the C and E options on the keypad and will either enter the code or clear the current input.

        int length = passwordText.text.ToString().Length;
        if (length < passwordLength) //Checks if the password is shorter than the limit otherwise will not allow it
        {
            passwordText.text = passwordText.text + inputted;
        }
    }

    private void Clear()
    {
        passwordText.text = "";
        passwordText.color = Color.white; //Changes colour to white when clearing and empties text.
    }

    private void Enter()
    {
        if (passwordText.text == password) //Checks if password is correct
        {
            grateAnim.Play("gratesOpen");   // Where the door actually opens !!!
            endCube.GetComponent<BoxCollider>().enabled = true;

            if (audioSource != null)
            {
                audioSource.PlayOneShot(correctSound); //Plays correct audio
            }

            passwordText.color= Color.green; //Changes colour of text to green
            StartCoroutine(clearCode()); //Starts another function at the same time
        }
        else
        {
            if (audioSource == null)
            {
                audioSource.PlayOneShot(wrongSound); //Plays wrong audio
            }

            passwordText.color = Color.red;
            StartCoroutine(clearCode());
        }
    }


    IEnumerator clearCode()
    {
        yield return new WaitForSeconds(0.75f); //Waits 3/4 of a second before running clear function
        Clear();
    }

    #endregion

}

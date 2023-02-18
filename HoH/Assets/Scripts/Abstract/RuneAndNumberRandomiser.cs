using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RuneAndNumberRandomiser : MonoBehaviour
{
    #region Parametres
    [Header("Arrays")]
    [SerializeField] private int[] numbers = new int[4];
    [SerializeField] private Sprite[] runes = new Sprite[8]; //Creates two unpopulated arrays (sprites populated in unity) and stores them in numbers and sprites

    [Header("Rune Code Order")]
    [SerializeField] private Image[] runeImagesOrder = new Image[4]; //Does the same as above, populated in Unity. Refers to the 4 images that will be ordered as the code is ordered

    [Header("Canvas Locations")]
    [SerializeField] private Canvas[] runeSpawnLocation = new Canvas[4]; //Similar to above

    
    [HideInInspector] public string passcode; //Public passcode so can be referenced via another script
    private Sprite[] shuffledSprites;
    private Canvas[] shuffledCanvas; //Unpopulated private arrays that will be used internally to reference the shuffled versions of the needed arrays
    #endregion

    private void Awake()
    {
        RandomiseKeypadCode(); //Calls before start function, needed for keypad to work
    }
    private void Start()
    {  
        ShuffleAllArrays();      
        RandomiseCanvasContents();
        CodeRuneOrder(); //Calls functions
    }

    #region Functions
    T[] ShuffleArray<T>(T[] array) //Takes array of type 'T' which is for any input
    {
        for (int t = 0; t < array.Length; t++) //Basic for loop, while t is smaller than the array, it will loop and t will increment
        {
            T temp = array[t]; //Sets up temporary variable temp of type T (any) and it is populated with array[t]
            int r = Random.Range(t, array.Length); //Generates random number that is between t and the total length of the array
            array[t] = array[r]; //array[t] is now populated with the random index "array[r]" that indexes the array using the randomly generated number
            array[r] = temp; //this resets the cycle and populates array[r] with the initial temp that came from array[t]
        }
        return array; //Returns the shuffled array
    }

    private void CodeRuneOrder()
    {
        for (int i = 0; i < runeImagesOrder.Length; i++) //for loop to ensure that all of the runeImagesOrder are changed
        {
            runeImagesOrder[i].sprite = runes[i]; //changes the runeImagesOrder sprite to the correspending rune sprite, ensuring it is ordered
        }
    }

    private void RandomiseCanvasContents()
    {
        for (int i = 0; i < runeSpawnLocation.Length; i++) //for loop that runs through all the canvas spawn location
        {
            shuffledCanvas[i].GetComponentInChildren<Image>().sprite = shuffledSprites[i];
            shuffledCanvas[i].GetComponentInChildren<TMP_Text>().text = numbers[i].ToString(); //ensures that the correct rune and number are put together to allow the player to solve the puzzle
        }
    }

    private void RandomiseKeypadCode() 
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = Random.Range(0, 10); //Generates numbers according to how large numbers[] is and populates it from 0-9
        }

        passcode = string.Join("", numbers); //puts those numbers into a single string to allow it to be used as a passcode
    }

    private void ShuffleAllArrays()
    {
        shuffledSprites = ShuffleArray(runes);
        shuffledCanvas = ShuffleArray(runeSpawnLocation); //Shuffles both arrays
    }

    #endregion
}

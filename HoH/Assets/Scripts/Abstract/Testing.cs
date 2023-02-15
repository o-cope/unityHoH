using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Testing : MonoBehaviour
{
    #region Parametres
    [Header("Arrays")]
    [SerializeField] private int[] numbers = new int[4];
    [SerializeField] private Sprite[] sprites = new Sprite[8];
    
    [Header("Passcode")]
    [SerializeField] public string passcode;

    [Header("Rune Code Order")]
    [SerializeField] private Image[] runeImagesOrder = new Image[4];

    [Header("Canvas Locations")]
    [SerializeField] private Canvas[] runeSpawnLocation = new Canvas[4];


    private Sprite[] shuffledSprites;
    private Canvas[] shuffledCanvas;

    #endregion
    private void Start()
    {
        RandomiseKeypadCode();
        ShuffleAllArrays();      
        RandomiseCanvasContents();
        CodeRuneOrder();
    }

    #region Functions
    T[] ShuffleArray<T>(T[] array)
    {
        for (int t = 0; t < array.Length; t++)
        {
            T temp = array[t];
            int r = Random.Range(t, array.Length);
            array[t] = array[r];
            array[r] = temp;
        }
        return array;
    }

    private void CodeRuneOrder()
    {
        for (int i = 0; i < runeImagesOrder.Length; i++)
        {
            runeImagesOrder[i].sprite = sprites[i];
        }
    }

    private void RandomiseCanvasContents()
    {
        for (int i = 0; i < runeSpawnLocation.Length; i++)
        {
            shuffledCanvas[i].GetComponentInChildren<Image>().sprite = shuffledSprites[i];
            shuffledCanvas[i].GetComponentInChildren<TMP_Text>().text = numbers[i].ToString();
        }
    }

    private void RandomiseKeypadCode()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = Random.Range(0, 10);
        }

        passcode = string.Join("", numbers);
    }

    private void ShuffleAllArrays()
    {
        shuffledSprites = ShuffleArray(sprites);
        shuffledCanvas = ShuffleArray(runeSpawnLocation);
    }

    #endregion
}

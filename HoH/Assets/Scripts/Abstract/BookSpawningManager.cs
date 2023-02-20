using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpawningManager : MonoBehaviour
{
    #region Parametres
    [Header("Spawn Locations")]
    [SerializeField] private GameObject[] bookSpawnLocation = new GameObject[6];

    private GameObject[] shuffledSpawnLocations;
    #endregion

    private void Awake()
    {
        shuffledSpawnLocations = ShuffleArray(bookSpawnLocation);
    }

    private void Start()
    {
        SpawnBooks();
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

    private void SpawnBooks()
    {
        for (int i = 0; i < 3; i++)
        {
            shuffledSpawnLocations[i].SetActive(true);
            Debug.Log("shuffledSpawnLocations"[i]);
        }
    }

    #endregion
}

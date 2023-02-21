using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonIceManager : MonoBehaviour
{
    #region Parametres
    [SerializeField] private GameObject[] dungeonIceLocations = new GameObject[2];
    private int rngNum;
    #endregion
    private void Awake()
    {
        rngNum = Random.Range(0, 2);
    }
    private void Start()
    {
        RandomiseSpawn();
    }

    #region Functions
    private void RandomiseSpawn()
    {
        dungeonIceLocations[rngNum].SetActive(true);
    }
    #endregion
}

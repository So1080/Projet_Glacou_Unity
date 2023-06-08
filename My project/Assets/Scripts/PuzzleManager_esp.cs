using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager_esp : MonoBehaviour
{
    [SerializeField] private List<PuzzlePiece> _piecePrefabs;
    [SerializeField] private Transform _slotParent, _pieceParent;


    void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Dechet").Length <= 0)
        {
            SceneManager.LoadScene("Win_esp");
        }
    }


    private void Spawn()
    {
        //var randomSetSlot = _slotPrefabs.OrderBy(s => Random.value).Take(2).ToList();
        //var randomSetPiece = _piecePrefabs.OrderBy(s => Random.value).Take(2).ToList();

        //var randomSetSlot = _slotPrefabs.ToList();
        var randomSetPiece = _piecePrefabs.ToList();

        /*
        for (int j = 0; j<randomSetSlot.Count; j++)
        {
            var spawnedSlot = Instantiate(randomSetSlot[j], _slotParent.GetChild(j).position, Quaternion.identity);
        }*/



        for (int i = 0; i < randomSetPiece.Count; i++)
        {

            var spawnedPiece = Instantiate(randomSetPiece[i], _pieceParent.GetChild(i).position, Quaternion.identity);
            spawnedPiece.Init();
        }

    }
}


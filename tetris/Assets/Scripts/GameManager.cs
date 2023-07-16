using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SpawnerManager spawner;
    BoardManager board;
    private BlokController aktifBlok;

    //public static GameManager Instance { get; set; }
    //public BlokController Current { get; set; }

    //public float GameSpeed => gameSpeed;
    //[SerializeField, Range(.1f, 1f)] private float gameSpeed = 1;

    void Start()
    {
      //spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnerManager>();
      //board = GameObject.FindGameObjectWithTag("Board").GetComponent<BoardManager>();

       board=GameObject.FindObjectOfType<BoardManager>();
       spawner = GameObject.FindObjectOfType<SpawnerManager>();


        if (spawner)
        {
            if(aktifBlok == null)
            {
                aktifBlok = spawner.firlatma();

            }
        }
    }

    
}


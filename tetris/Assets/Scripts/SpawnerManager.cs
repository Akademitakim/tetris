using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

    [SerializeField] BlokController[] blocks; 
   

    public BlokController firlatma()
    {
        int randomBlok= Random.Range(0, blocks.Length);
        BlokController blok = Instantiate(blocks[randomBlok] , transform.position,Quaternion.identity) as BlokController;



        if( blok != null )
        {
            return blok;
        }else
        { 
            return null; 
        }    

    }
     
    
}

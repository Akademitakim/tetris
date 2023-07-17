using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMan : MonoBehaviour
{
    [SerializeField] BlokControl[] blocks;



  

    public BlokControl firlatma()
    {
        int randomBlok = Random.Range(0, blocks.Length);
        BlokControl blok = Instantiate(blocks[randomBlok], transform.position, Quaternion.identity) as BlokControl;



        if (blok != null)
        {
            return blok;
        }
        else
        {
            return null;
        }

    }
}

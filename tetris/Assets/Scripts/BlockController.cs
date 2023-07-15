using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private bool donerMi=true;


    private void Start()
    {
        // InvokeRepeating("asagiHareket", 0f, .50f);
        // InvokeRepeating("solaDon", 0f, 2f);

        StartCoroutine(asagiHareket());
    }
    public void solaHareket()
    {
        transform.Translate(new Vector3(-1, 0, 0));
   
    }

    public void sagaHareket()
    {
        transform.Translate(new Vector3(1, 0, 0));
    }

   /* public void asagiHareket()
    {
        transform.Translate(new Vector3(0, -1, 0));
    }*/

    public void yukariHareket()
    {
        transform.Translate(new Vector3(0, 1, 0));
    }



    public void sagaDon()
    {
        if (donerMi)
        {
            transform.Rotate(0, 0, -90);
        }

    }
    public void solaDon()
    {
        if (donerMi)
        {
            transform.Rotate(0, 0, 90);
        }

    }


    IEnumerator asagiHareket()
    {
        while (true) { 
      
            
            yield return new WaitForSeconds(.5f);
            var position =transform.position;
            position.y--;
            transform.position= position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlokController : MonoBehaviour
{
    [SerializeField] private bool donerMi=true;


    private void Start()
    {
        

        StartCoroutine(asagiHareket());



        //GameManager.Instance.Current = this;



    }
    public void solaHareket()
    {
        // transform.Translate(new Vector3(-1, 0, 0));
        transform.Translate(Vector3.left, Space.World);
   
    }

    public void sagaHareket()
    {
        // transform.Translate(new Vector3(1, 0, 0));
        transform.Translate(Vector3.right, Space.World);
    }

   

    public void yukariHareket()
    {
        //transform.Translate(new Vector3(0, 1, 0));
        transform.Translate(Vector3.up, Space.World);
    }



    IEnumerator asagiHareket()
    {
        while (true) {
            //var delay = GameManager.Instance.GameSpeed;
            yield return new WaitForSeconds(.5f);
            var position =transform.position;
            position.y--;
            transform.position= position;
        }
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


    
}





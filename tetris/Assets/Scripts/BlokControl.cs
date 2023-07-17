using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlokControl : MonoBehaviour
{
    [SerializeField] private bool donerMi = true;


    private void Start()
    {


        // StartCoroutine(asagiHareket());
        StartCoroutine(hareketSikligi());
    }


    public void solaHareket()
    {

        transform.Translate(Vector3.left, Space.World);

    }

    public void sagaHareket()
    {

        transform.Translate(Vector3.right, Space.World);
    }


    public void yukariHareket()
    {

        transform.Translate(Vector3.up, Space.World);
    }



      public void asagiHareket()
  {
      transform.Translate(Vector3.down,Space.World);
  }



  IEnumerator hareketSikligi()
  {
      while(true) { 
      yield return new WaitForSeconds(.25f);}
  }
    


   /* public IEnumerator asagiHareket()
    {
        while (true)
        {
            //var delay = GameManager.Instance.GameSpeed;
            yield return new WaitForSeconds(.5f);
            var position = transform.position;
            position.y--;
            transform.position = position;
        }
    }
   */




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

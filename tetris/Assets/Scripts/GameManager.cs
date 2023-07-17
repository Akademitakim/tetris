using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SpawnMan spawner;
    BorderManager border;
    private BlokControl aktifBlok;


    [Header("Sayaclar")]
   [Range(0.02f,1f)]
    [SerializeField] private float firlatmaSuresi = .1f;
    private float firlatmaSayac=0;
    [Range(0.02f, 1f)]
    [SerializeField] private float sagSolTusaBasmaSuresi = 0.25f;
    float sagSolTusaBasmaSayac;
    [Range(0.02f, 1f)]
    [SerializeField] private float sagSolDonmeSuresi = 0.25f;
    float sagSolDonmeSayac;
    [Range(0.02f, 1f)]
    [SerializeField] private float asagiTusaBasmaSuresi = 0.25f;
    float asagiTusaBasmaSayac;


    private bool gameOver = false;



    void Start()
    {
        border = GameObject.FindObjectOfType<BorderManager>();
        spawner = GameObject.FindObjectOfType<SpawnMan>();


        if (spawner)
        {
            if (aktifBlok == null)
            {
                aktifBlok = spawner.firlatma();
                aktifBlok.transform.position = vectorYerlesim(aktifBlok.transform.position);
            }
        }

    }



    private void Update()
    {
        if (!border || !spawner || !aktifBlok || gameOver)
        {
            return;
        }


        inputKontrol();
    }




    void inputKontrol()
    {

        if ((Input.GetKey("right") && Time.time > sagSolTusaBasmaSayac) || Input.GetKeyDown("right"))
        {
            aktifBlok.sagaHareket();
            sagSolTusaBasmaSayac = Time.time + sagSolTusaBasmaSayac;

            if (!border.gecerliPozisyondaMi(aktifBlok))
            {
                aktifBlok.solaHareket();
            }
            
        }


        else if ((Input.GetKey("left") && Time.time > sagSolTusaBasmaSayac) || Input.GetKeyDown("left"))
        {
            aktifBlok.solaHareket();
            sagSolTusaBasmaSayac = Time.time + sagSolTusaBasmaSayac;

            if (!border.gecerliPozisyondaMi(aktifBlok))
            {
                aktifBlok.sagaHareket();
            }

        }
        else if ((Input.GetKeyDown("up") && Time.time > sagSolDonmeSayac))
        {
            aktifBlok.sagaDon();
            sagSolDonmeSayac = Time.time + sagSolDonmeSuresi;

            if (!border.gecerliPozisyondaMi(aktifBlok))
            {
                aktifBlok.solaDon();
            }

        }

        else if ((Input.GetKey("down") && Time.time > asagiTusaBasmaSayac) || Time.time > firlatmaSayac)
        {
            firlatmaSayac = Time.time + firlatmaSayac;
            asagiTusaBasmaSayac = Time.time + asagiTusaBasmaSayac;

            if (aktifBlok)
            {
                aktifBlok.asagiHareket();

                if (!border.gecerliPozisyondaMi(aktifBlok))
                {


                    if (border.DisariTastiMi(aktifBlok))
                    {
                        aktifBlok.yukariHareket();
                        gameOver = true;
                    }
                    else
                    {
                        Yerlesti();
                    }

                }

            }
        }

    }

    private void Yerlesti()
    {

        sagSolTusaBasmaSayac = Time.time;
        asagiTusaBasmaSayac= Time.time;
        sagSolDonmeSayac= Time.time;
        aktifBlok.yukariHareket();
        border.izgara›cineAl(aktifBlok);
        if (spawner)
        {
            aktifBlok = spawner.firlatma();
        }

        border.tumSatirlariTemizle();
    }




    Vector2 vectorYerlesim(Vector2 vector)
    {
        return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
    }
}

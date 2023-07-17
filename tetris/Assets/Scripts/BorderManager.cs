using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderManager : MonoBehaviour
{
    [SerializeField] private Transform barrier;

    public int yukseklik = 20;
    public int genislik = 10;


    private Transform[,] izgara;


    private void Awake()
    {
        izgara=new Transform[genislik,yukseklik];
        
    }

    private void Start()
    {
        kareOlustur();
    }


    bool border›cindeMi(int x, int y)
    {
        return (x >= 0 && x < genislik && y >= 0);

    }




     bool KareDoluMu(int x , int y, BlokControl block)
    {
        return (izgara[x,y] !=null && izgara[x,y].parent!= block.transform);
    }

    



    public bool gecerliPozisyondaMi(BlokControl block)
    {
        foreach (Transform child in block.transform)
        {
            Vector2 pozisyon = vectorYerlesim(child.position);

            if (!border›cindeMi((int)pozisyon.x, (int)pozisyon.y))
            {
                return false;
            }
            if (pozisyon.y < yukseklik)
            {
                if (KareDoluMu((int)pozisyon.x, (int)pozisyon.y, block))
                {
                    return false;
                }

            }

        }
        return true;

    }



    void kareOlustur()
    {
        if (barrier != null)
        {
            for (int y = 0; y < yukseklik; y++)
            {
                for (int x = 0; x < genislik; x++)
                {
                    Transform tile = Instantiate(barrier, new Vector3(x, y, 0) , Quaternion.identity);

                    tile.name = "g: " + x.ToString() + "y : " + y.ToString();

                    tile.parent = this.transform;
                }
            }
        }
        else
        {
            print("Barrier yok");

        }
    }


    public void izgara›cineAl(BlokControl block)
    {
        if (block == null) return;
        foreach (Transform child in block.transform)
        {
            Vector2 pozisyon = vectorYerlesim(child.position);
            izgara[(int)pozisyon.x, (int)pozisyon.y] = child;
        }
    }


    bool satirTamamlandiMi(int y)
    {
        for (int x=0;x<genislik;++x) {

            if (izgara[x,y] == null)
            {
                return false;
            }
            
        }
        return  true;
    }




    void satirTemizleme(int y)
    {
        for (int x = 0; x < genislik; ++x)
        {
            if (izgara[x, y] != null)
            {
                Destroy(izgara[x, y].gameObject);
            }

            izgara[x, y]=null;
        }
    }


    void satirAsagi›n(int y)
    {

        for (int x = 0; x < genislik; ++x)
        {
            if (izgara[x,y] != null)
            {
                izgara[x, y - 1] = izgara[x,y];
                izgara[x, y] = null;

                izgara[x, y - 1].position += Vector3.down;
            }
        }
    }

    void tumSatirAsagi›n(int baslangicy)
    {

        for (int i = baslangicy; i < yukseklik; ++i)
        {
            satirAsagi›n(i);
        }
    }


    public void tumSatirlariTemizle()
    {
        for (int y = 0; y < yukseklik; y++)
        {
            if (satirTamamlandiMi(y))
            {
                satirTemizleme(y);
                tumSatirAsagi›n(y + 1);
                y--;
            }
        }
    }


    public bool DisariTastiMi(BlokControl block)
    {
        foreach (Transform child in block.transform)
        {
            if (child.transform.position.y >= yukseklik - 1)
            {
                return true;
            }
        }
        return false;
    }

    Vector2 vectorYerlesim(Vector2 vector)
    {
        return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
    }
}

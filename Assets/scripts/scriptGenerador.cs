using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptGenerador : MonoBehaviour
{
    public GameObject[] arrayObjetos;
    public List<GameObject> listaObjetosMoneda;
    public List<GameObject> listaObjetosRoca;
    public List<GameObject> listaObjetosPoder;

    public float frecuenciaSpawn;
    public float minX;
    public float maxX;
    public float estableY;

    // Start is called before the first frame update
    void Start()
    {
        frecuenciaSpawn = 0.5f;
        InvokeRepeating("generarObjeto", 1, frecuenciaSpawn);
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    void generarObjeto()
    {
        int numRandom =  Random.Range(0, 101);

        if (numRandom <= 70)
        {
            //salemoneda

            if (listaObjetosMoneda.Count <= 0)
            {
                GameObject moneda = Instantiate(arrayObjetos[0]);

                //ojo
                moneda.GetComponent<sriptObjetosCaen>().scriptGenerador = this;
                
                añadirAlist(listaObjetosMoneda, moneda);
                expulsarDeList(listaObjetosMoneda);

            }
            else
            {
                expulsarDeList(listaObjetosMoneda);
            }



        }
        else if (numRandom >= 71&&numRandom<=95)
        {
            //sale roca


            if (listaObjetosMoneda.Count <= 0)
            {
                GameObject roca = Instantiate(arrayObjetos[1]);
                añadirAlist(listaObjetosRoca, roca);
                expulsarDeList(listaObjetosRoca);

            }
            else
            {
                expulsarDeList(listaObjetosRoca);
            }

        }
        else if (numRandom >= 100)
        {
            //sale power
            if (listaObjetosMoneda.Count <= 0)
            {
                GameObject power = Instantiate(arrayObjetos[2]);
                añadirAlist(listaObjetosPoder, power);
                expulsarDeList(listaObjetosPoder);

            }
            else
            {
                expulsarDeList(listaObjetosPoder);
            }

        }
    }


    public void añadirAlist(List<GameObject> lista,GameObject objeto)
    {
        objeto.SetActive(false);
        lista.Add(objeto);
    }

    public void expulsarDeList(List<GameObject> lista)
    {
        lista[0].SetActive(true);
       
        lista[0].transform.position = darPosicionInicial();
        lista.RemoveAt(0);

        
    }

    Vector2 darPosicionInicial()
    {
        float n = Random.Range(minX, maxX);
        Vector2 posicion = new Vector2(n, estableY);
        return posicion;
    }

   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sriptObjetosCaen : MonoBehaviour
{
    public scriptGenerador scriptGenerador;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y+speed*Time.deltaTime);
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "destructor")
        {
            if (this.gameObject.tag == "coin")
            {
                scriptGenerador.a�adirAlist(scriptGenerador.listaObjetosMoneda,this.gameObject);
            }
            else if (this.gameObject.tag == "piedra")
            {
                scriptGenerador.a�adirAlist(scriptGenerador.listaObjetosRoca, this.gameObject);
            }
            else if (this.gameObject.tag == "poder")
            {
                scriptGenerador.a�adirAlist(scriptGenerador.listaObjetosPoder, this.gameObject);
            }

        }
    }
}

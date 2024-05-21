using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptMovimiento : MonoBehaviour
{
    public int fuerzaDeSalto;
    public int velocidad;
    Rigidbody2D rigidbody2;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento();
        salto();
    }

    void movimiento()
    {
        if(Input.GetKey("d"))
        {
            transform.position = new Vector2(transform.position.x + velocidad * Time.deltaTime, transform.position.y);

        }
        else if (Input.GetKey("a"))
        {
            transform.position = new Vector2(transform.position.x - velocidad * Time.deltaTime, transform.position.y);

        }

    }

    void salto()
    {
        if (Input.GetKeyDown("w"))
        {
            rigidbody2.AddForce(Vector2.up * fuerzaDeSalto, ForceMode2D.Impulse);
        }
    }
}

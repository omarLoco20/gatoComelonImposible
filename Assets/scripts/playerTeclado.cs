using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTeclado : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimientoTeclado();
    }
    void movimientoTeclado()
    {
        if (Input.GetKey("a"))
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        else if (Input.GetKey("d"))
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
    }
}

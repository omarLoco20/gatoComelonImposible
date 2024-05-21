using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]


public class player : MonoBehaviour
{
    Rigidbody2D rb2d;
    BoxCollider2D bc2d;
    SpriteRenderer sr;

    public FloatingJoystick joy;
    public Vector2 joyMove;

    float xMove;
   // float yMove;
    public float speed = 5;
    public float puntoFijo;


    //GAME
    public scriptGenerador _sg;
    int life;
    int monedas;
    int tiempoJugado;
    public GameObject pnlPause;
    float timeSpawn;
    public GameObject gatoBocon;
    // INTEFRAZ
    public TextMeshProUGUI txtLife;
    public TextMeshProUGUI txtCoin;
    public TextMeshProUGUI txtTime;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        life = 3;
        monedas = 0;
        txtLife.text = "LIFE: " + life;
        txtCoin.text = monedas.ToString();
        InvokeRepeating("temporizador", 1, 1);
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
       // xMove = Input.GetAxisRaw("Horizontal");
       // yMove = Input.GetAxisRaw("Vertical");
        joyMove = joy.Direction;
        transform.position = new Vector2(transform.position.x, puntoFijo);
       // movimientoTeclado();


        
    }

    private void FixedUpdate()
    {
        rb2d.velocity = joyMove.normalized*speed;   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            monedas++;
            _sg.añadirAlist(_sg.listaObjetosMoneda,collision.gameObject);
            actualizarTxt(txtCoin, monedas, "COINS: ");
            crecer();
            comer();
            
        }else if(collision.gameObject.tag =="piedra")
        {
            life--;
            _sg.añadirAlist(_sg.listaObjetosRoca, collision.gameObject);
            actualizarTxt(txtLife, life, "LIFE: ");
            comer();
            if (life <= 0)
            {
                perdio();

            }

        }
        else if (collision.gameObject.tag == "poder")
        {
            monedas = monedas * 2;
            _sg.añadirAlist(_sg.listaObjetosPoder, collision.gameObject);

            actualizarTxt(txtCoin, monedas, "COINS: ");
            comer();

        }
    }


    void actualizarTxt(TextMeshProUGUI text,int num,string tipoTxt)
    {
        text.text = tipoTxt+ num.ToString();
    }

    void temporizador()
    {
        tiempoJugado++;
        txtTime.text = "TIME: " + tiempoJugado;
        if (/*tiempoJugado % 1 == 0 &&*/ tiempoJugado % 10 == 0)
        {
            _sg.frecuenciaSpawn = _sg.frecuenciaSpawn - 0.1f;
        }

    }

    void perdio()
    {
        Time.timeScale = 0;
        pnlPause.SetActive(true);

    }
    void crecer()
    {
        this.gameObject.transform.localScale = new Vector2(transform.localScale.x+transform.localScale.x*0.1f,transform.localScale.y + transform.localScale.y * 0.1f);
    }
    
    void comer()
    {
        gatoBocon.SetActive(true);
        Invoke("desactivarGatoBocon", 0.5f);
    }

    void desactivarGatoBocon()
    {
        gatoBocon.SetActive(false);

    }
}

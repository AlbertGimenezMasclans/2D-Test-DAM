using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numero : MonoBehaviour
{
    private float _vel;

    public Sprite[] spriteNumeros = new Sprite[10];

    private int valorNum;
    private Vector2 minPantalla;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 3f;

        System.Random aleatori = new System.Random();
        valorNum = aleatori.Next(0, 10);
        GetComponent<SpriteRenderer>().sprite = spriteNumeros[valorNum];

        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 NovaPos = transform.position;
        NovaPos = NovaPos + new Vector2(0,-1) * _vel * Time.deltaTime;
        transform.position = NovaPos;

        if (transform.position.y < minPantalla.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "ProjectilJugador" || objecteTocat.tag == "NauJugador")
        {
            Destroy(gameObject);
        }
    }
}

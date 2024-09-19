using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NouJugador : MonoBehaviour
{
    private float _vel;

    private Vector2 minPantalla;
    private Vector2 maxPantalla;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8;

         minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
         maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        minPantalla.x = minPantalla.x + 0.75f;
        maxPantalla.x = maxPantalla.x + 0.75f;
        minPantalla.y = minPantalla.y + -0.75f;
        maxPantalla.y = maxPantalla.y + -0.75f;
    }

    // Update is called once per frame
    void Update()
    {

        float DirX = Input.GetAxisRaw("Horizontal");
        float DirY = Input.GetAxisRaw("Vertical");

        //Debug.Log("X: " + DirX + " + Y: " + DirY);

        Vector2 Dir = new Vector2 (DirX, DirY).normalized;
        Vector2 NewPos = transform.position;
        NewPos = NewPos + Dir * _vel * Time.deltaTime;
        NewPos.x = Mathf.Clamp(NewPos.x, minPantalla.x, maxPantalla.x);
        NewPos.y = Mathf.Clamp(NewPos.y, minPantalla.y, maxPantalla.y);
        transform.position = NewPos;

    }
}

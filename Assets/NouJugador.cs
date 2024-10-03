using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NouJugador : MonoBehaviour
{
    private float _vel;
    
    private Vector2 minPantalla;
    private Vector2 maxPantalla;

    [SerializeField]
    private GameObject prefabProjectil;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8;

         minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
         maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float midaMeitatImatgeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float midaMeitatImatgeY = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        // minPantalla.x = minPantalla.x + 1f;
        //minPantalla.x += 1f; // Es sinónim a la línia de dalt.
        minPantalla.x += midaMeitatImatgeX;
        maxPantalla.x -= midaMeitatImatgeX;
        minPantalla.y += midaMeitatImatgeY;
        maxPantalla.y -= midaMeitatImatgeY;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentNau();
        DisparaProjectil();
    }

    private void MovimentNau()
    {
        float DirX = Input.GetAxisRaw("Horizontal");
        float DirY = Input.GetAxisRaw("Vertical");

        //Debug.Log("X: " + DirX + " + Y: " + DirY);

        Vector2 Dir = new Vector2(DirX, DirY).normalized;
        Vector2 NewPos = transform.position;
        NewPos = NewPos + Dir * _vel * Time.deltaTime;
        NewPos.x = Mathf.Clamp(NewPos.x, minPantalla.x, maxPantalla.x);
        NewPos.y = Mathf.Clamp(NewPos.y, minPantalla.y, maxPantalla.y);
        transform.position = NewPos;
    }

    private void DisparaProjectil()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject Projectil = Instantiate(prefabProjectil);
            Projectil.transform.position = transform.position;
        }
    }
}

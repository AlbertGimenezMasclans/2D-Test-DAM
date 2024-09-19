using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NouJugador : MonoBehaviour
{
    private float _vel;

    // Start is called before the first frame update
    void Start()
    {

        _vel = 8;
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
        transform.position = NewPos;
    }
}

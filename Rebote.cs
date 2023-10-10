using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebote : MonoBehaviour
{
    public float fuerzaSalto = 350;
    bool onGround = true;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Salto();
        }
    }

    void Salto()
    {
        if(onGround)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerzaSalto);
            Debug.Log("He saltado");
            onGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        Debug.Log("He tocado el suelo");
    }
}

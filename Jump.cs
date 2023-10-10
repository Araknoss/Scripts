using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    
    public float fuerzaSalto = 350;
    bool onGround=true;
    bool canDoubleJump = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        Debug.Log("He tocado el suelo");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
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
            canDoubleJump = true;
        }
        else if (canDoubleJump)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerzaSalto);
            Debug.Log("Doble Salto");
            canDoubleJump = false;
        }
    }
}

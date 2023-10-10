using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    bool up = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float velocidad = 5;
    // Update is called once per frame
    void Update()
    {
        
        if (up==false)
        {
            transform.Translate(Vector2.down * Time.deltaTime*velocidad);
            if (transform.position.y < -2)
            {
                up = true;
            }
        }
        else if (up==true)
{
            transform.Translate(Vector2.up * Time.deltaTime*velocidad);
            if (transform.position.y >= 3)
            {
                up = false;
            }
        }

       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2D : MonoBehaviour
{
    
    public float velocidad = 2;
    
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        Vector3 ejey = Input.GetAxis("Jump") * Vector3.up * Time.deltaTime * velocidad;
        transform.Translate(ejey);
    }

}  

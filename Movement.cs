using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocidad = 2;
    public float velGiro = 50;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidad = 4;
            Debug.Log("Estás corriendo");
        }
        else
        {
            velocidad = 2;
        }
        Vector2 ejex = Vector2.right * Time.deltaTime * velocidad * Input.GetAxis("Horizontal");
       /* Vector2 ejey = Vector2.up * Time.deltaTime * velocidad * Input.GetAxis("Vertical");
        Vector3 ejez = Vector3.forward * Time.deltaTime * velGiro * Input.GetAxis("Jump");*/
        transform.Translate(ejex); 
        /*transform.Rotate(ejez);*/
    }
   
}

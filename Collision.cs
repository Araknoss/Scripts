using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collision : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    bool timerBool = true;
    public float timer = 0;
    public Text textoTimer;
    public TextMeshProUGUI textoTimerPro;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(lanzarayo.transform.position, transform.right, 1);
      if (hit==true)
      {
            if (hit.collider.gameObject.tag == "caja")
            {
                if(Input.GetButtonDown("Interact"))
                {
                    Destroy(hit.collider.gameObject);
                    timerBool = false;
                    Debug.Log("Has realizado el recorrido en " + textoTimerPro.text + " segundos");
                }
                Debug.Log("Recoger objeto");
            }
      }

        /* Timer */
        if (timerBool == true)
        {
            timer += Time.deltaTime;
            textoTimerPro.text = "" + timer.ToString("f0"); /*fn donde n=numero decimales.*/
        }
    }

    public GameObject lanzarayo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.transform.tag=="caja")
        {
            Destroy(collision.gameObject);
        }
        */

        if (collision.transform.tag == "fall")
        {
          
        }
    }
}

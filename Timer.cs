using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; /*Biblioteca específica para texto*/
using TMPro;

public class Timer : MonoBehaviour
{
    bool timerBool = true;
    public float timer = 0;
    public Text textoTimer;
    public TextMeshProUGUI textoTimerPro;
    void Update()
    {
        
            timer += Time.deltaTime;
            textoTimerPro.text = "" + timer.ToString("f0"); /*fn donde n=numero decimales.*/
        
    }
}

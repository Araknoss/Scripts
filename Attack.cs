using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Animator anim;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown ("Fire1"))
        {
            anim.SetTrigger("Attack");
        }
    }
}

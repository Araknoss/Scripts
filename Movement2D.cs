using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private Rigidbody2D rb2D;

    /*Declarando variables de movimiento*/
    [Header("Movimiento")]
    public float movimientoHorizontal = 0f;
    public float velocidadDeMovimiento;
    [Range(0, 0.3f)] public float suavizadoDelMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    /*Declarando variables de salto*/
    [Header("Salto")]
    public float fuerzaDeSalto;
    public LayerMask queEsSuelo;
    public Transform controladorSuelo;
    public Vector3 dimensionesCaja;
    public bool enSuelo;
    private bool salto = false;

    /*Declaramos la variable animator*/
    [Header("Animaciones")]
    private Animator animator;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
        //Le asignamos a la variable animator el componente 
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //Mover
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        //Salto
        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }

        //Animacion de saltar y caer
        animator.SetFloat("Speed", rb2D.velocity.y);

        //Animación de correr, asignamos ("Parámetro, en este caso le hemos llamado move", "el valor del movimiento horizontal (lin 42) como valor absoluto (siempre positivo)")
        animator.SetFloat("Move",Mathf.Abs(movimientoHorizontal));
    }

    private void FixedUpdate()
    {
        //Mover
        Mover(movimientoHorizontal * Time.fixedDeltaTime,salto);

        //Salto
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja,0f, queEsSuelo);
        salto = false;

        //Animacion salto, asignamos ("nombre que le hemos dado al parámetro del animator", "el valor de enSuelo que es un booleano")
        animator.SetBool("OnFloor", enSuelo);

        salto = false;
    }

    private void Mover(float mover, bool saltar)
    {
        //Funciones de movimiento
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDelMovimiento);

        if (mover > 0 && mirandoDerecha == false)
        {
            //Girar
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            //Girar
            Girar();
        }
        if(enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
    }
    private void Girar()
    {
            mirandoDerecha = !mirandoDerecha;
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}

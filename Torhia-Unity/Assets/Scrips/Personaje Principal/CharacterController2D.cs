using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

	public float altura;
    [SerializeField] private float MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField] private float JumpForce = 400f;                  // Amount of force added when the player jumps.
    [SerializeField] private LayerMask suelo;                         // A mask determining what is ground to the character

    private bool facingRight = true;

    const float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    public bool grounded;            // Whether or not the player is grounded.
    // no hay animaciones
    private Rigidbody2D rb;




    public Transform sueloCheck;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        Controles(); // movimiento en x
        Salto();     // por lo que he leido, todo lo que tenga que ver con fuerzas va en el fixed update ( saltar es uan fuerza )
    }

    void Update()
    {

        //TOCA SUELO ??
        Debug.DrawLine(transform.position,(transform.position +(-transform.up * altura/2-transform.up*0.2f)),Color.red);
		grounded =Physics2D.Raycast(transform.position ,-Vector3.up , altura/2+0.2f, suelo);
       // grounded = Physics2D.OverlapCircle(sueloCheck.position, groundedRadius, suelo);

    }


    void Controles()
    {

        //WALK ??
        if (Input.GetAxis("Horizontal") > 0)
        {
            float move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * MaxSpeed, rb.velocity.y);

            /*if (move > 0 && !facingRight)
                Flip();
            else if (move < 0 && facingRight)
                Flip();*/

        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            float move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * MaxSpeed, rb.velocity.y);

            /*if (move > 0 && !facingRight)
                Flip();
            else if (move < 0 && facingRight)
                Flip();*/

        }

    }



    void Salto()
    {
        // SALTO ??
        if (grounded && Input.GetKeyDown(KeyCode.Space))
            // rb.AddForce(new Vector2(0, JumpForce));        
            rb.velocity = Vector2.up * JumpForce;
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

}


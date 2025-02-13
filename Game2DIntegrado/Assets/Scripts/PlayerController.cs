using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Referencias
    [Header("Referencias al personaje")]
    [SerializeField] Rigidbody2D PlayerRB;
    [SerializeField] Animator Anim;
    [SerializeField] PlayerInput Input;

    [Header("MovementParameters")]
    private Vector2 moveInput;
    public float speed;
    float regularSpeed;
    private bool isFacingRight = true;

    [Header("Sprint")]
    [SerializeField] private float velocidadDeMovimientoBase;
    [SerializeField] private float velocidadExtra;
    [SerializeField] private float tiempoSprint;
        private float tiempoActualSprint;
    private float tiempoSiguienteSprint;
    [SerializeField] private float tiempoEntreSprints;
    private bool puedeCorrer = false;
    private bool estaCorriendo = false;



    [Header("JumpParameters")]
    public float jumpForce;
    public bool isJumping;
    [SerializeField] private float jumpCooldown = 0.5f; // ⏳ Cooldown del salto
    private bool canJump = true; // 🔒 Controla si se puede saltar


    //GroundCheck
    [SerializeField] bool isGrounded;
    [SerializeField] Transform GroundCheck;
    [SerializeField] float groundcheckRadius = 0.3f;
    [SerializeField] LayerMask groundLayer;

    [Header("Slide Parameters")]
    [SerializeField] private float slideSpeed = 8f;
    [SerializeField] private bool isSliding = false;
    private bool canSlide = true; // Controla si el jugador puede deslizarse

    #endregion
    #region Start y Update
    void Start()
    {
        //autoreferenciar componentes: nombre de variable = GetComponent()
        Input = GetComponent<PlayerInput>();
        PlayerRB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        regularSpeed = speed;
        tiempoActualSprint = tiempoSprint;

    }

    
    void Update()
    {
        groundCheck();
        
        if (isSliding) speed = slideSpeed;
        else if (!isSliding && !estaCorriendo) speed = regularSpeed;

        if (estaCorriendo)
        {
            tiempoActualSprint -= Time.deltaTime;
            if (tiempoActualSprint <= 0)
            {
                TerminarSprint();
            }
        }

    }

    #endregion
    #region void
    private void FixedUpdate()
    {
        movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isJumping)
        {
            isJumping = false;
            Anim.SetBool("IsJumping", false);
        }
    }
    void movement()
    {
        PlayerRB.velocity = new Vector3(moveInput.x * speed, PlayerRB.velocity.y, 0);
        if (moveInput.x > 0 && !isFacingRight) Flip();
        if (moveInput.x < 0 && isFacingRight) Flip();
    }

    void groundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, groundcheckRadius, groundLayer);
    }
    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Enemy"))
        {
            OpcionesManager.instancia.GameOver.SetActive(true);
            OpcionesManager.instancia.UIGame.SetActive(false);
            Manager.Instancia.MenuPausa.SetActive(false);
            Time.timeScale = 0;
        }

        if (collision.CompareTag("PickUp"))
        {
            ActivarSprint();
        }
    }
    private IEnumerator ResetJumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true; // ✅ Habilita el salto de nuevo
    }
    void ActivarSprint()
    {
        puedeCorrer = true;
        tiempoActualSprint = tiempoSprint;
        Debug.Log("Sprint activado");
    }

    void TerminarSprint()
    {
        Debug.Log("Sprint terminado");
        puedeCorrer = false;
        estaCorriendo = false;
        speed = velocidadDeMovimientoBase;
    }
    #endregion
    #region InputSystem
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (moveInput.x > 0 || moveInput.x < 0) Anim.SetBool("IsRunning", true);
        else Anim.SetBool("IsRunning", false);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        // Bloquear el salto si el juego está pausado
        if (!canJump || !isGrounded || isSliding) return;

        if (context.started)
        {
            isJumping = true;
            canJump = false; // ❌ Bloquea futuros intentos de salto
            Anim.SetBool("IsJumping", true);
            Invoke(nameof(jumpit), 0.3f);
            StartCoroutine(ResetJumpCooldown()); // ⏳ Inicia cooldown
        }
    }
    public void jumpit()
    {
        PlayerRB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }
        public void OnSlide(InputAction.CallbackContext context)
    {
        if (context.started && isGrounded && canSlide)
        {
            Anim.SetTrigger("Slide");
          
        }
    }
    public void Sprints(InputAction.CallbackContext context)
    {
      if (context.performed && puedeCorrer)
        {
            speed = velocidadExtra;
            estaCorriendo = true;
        }
       else if (context.canceled)
            {
            speed = velocidadDeMovimientoBase;
            estaCorriendo = false;
        }
 
    }
    

    #endregion
    #region Animation Events
    public void Sliding()
    {
        canSlide = false;
        isSliding = true;
    }

    public void SlidingEnd()
    {
        isSliding = false;
        Invoke(nameof(ResetSlide), 1);
    }

    public void ResetSlide()
    {
        canSlide = true;
    }
   
    
        #endregion
}

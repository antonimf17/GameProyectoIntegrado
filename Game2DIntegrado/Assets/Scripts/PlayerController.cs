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

    [Header("JumpParameters")]
    public float jumpForce;
    public bool isJumping;
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
    }

    
    void Update()
    {
        groundCheck();
        
        if (isSliding) speed = slideSpeed;
        else speed = regularSpeed;

        
    
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
        if (Time.timeScale == 0) return;

        if (context.started && isGrounded)
        {
            isJumping = true;
            Anim.SetBool("IsJumping", true);
            Invoke(nameof(jumpit), 0.3f);
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

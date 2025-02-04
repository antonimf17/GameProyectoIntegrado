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

    [Header("JumpParameters")]
    public float jumpForce;
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
    void movement()
    {
        PlayerRB.velocity = new Vector3(moveInput.x * speed, PlayerRB.velocity.y, 0);
    }

    void groundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, groundcheckRadius, groundLayer);
    }
 
    #endregion
    #region InputSystem
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if(isGrounded)
            {
                PlayerRB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            }
        }
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

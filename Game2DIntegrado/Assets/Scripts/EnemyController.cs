using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Referencias al enemigo")]
    [SerializeField] Rigidbody2D EnemyRB;
    [SerializeField] Animator Enemyanim;

    [Header("Movimientos Parametros")]
    [SerializeField] float speed;
    [SerializeField] Vector2 movement;

    [Header("VariablesEnemigo")]
    [SerializeField] Transform player;

    private bool isFacingRight = true;



    // Start is called before the first frame update
    void Start()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
        Enemyanim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        // Movimiento hacia el jugador (puedes ajustar la velocidad)
        Vector2 movement = new Vector2(direction.x, 0); // Solo movimiento en X (si solo quieres que se mueva horizontalmente)

        // Mueve al enemigo
        EnemyRB.MovePosition(EnemyRB.position + movement * speed * Time.deltaTime);

        if (direction.x > 0 && !isFacingRight) Flip();
        if (direction.x < 0 && isFacingRight) Flip();
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
        if (collision.gameObject.CompareTag("Objeto"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}

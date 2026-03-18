using UnityEngine;

public class Goomba : MonoBehaviour
{
    [SerializeField] private Transform puntoA;
    [SerializeField] private Transform puntoB;
    [SerializeField] private float velocidad = 2f;

    private Transform objetivoActual;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        objetivoActual = puntoA;
        
        rb.freezeRotation = true; 
    }

    void Update()
    {
        float direccionX = (objetivoActual.position.x > transform.position.x) ? 1 : -1;
        
        rb.linearVelocityX = direccionX * velocidad;
        sr.flipX = (direccionX < 0);

        if (Mathf.Abs(transform.position.x - objetivoActual.position.x) < 0.1f)
        {
            objetivoActual = (objetivoActual == puntoA) ? puntoB : puntoA;
        }
    }

    private void OnDrawGizmos()
    {
        if (puntoA != null && puntoB != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(puntoA.position, puntoB.position);
            Gizmos.DrawWireSphere(puntoA.position, 0.2f);
            Gizmos.DrawWireSphere(puntoB.position, 0.2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpriteRenderer rendererMario = collision.gameObject.GetComponent<SpriteRenderer>();
            
            if (rendererMario != null)
            {
                rendererMario.enabled = false;
            }

            collision.gameObject.SetActive(false); 
        }
    }
}
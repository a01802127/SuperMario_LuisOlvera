using UnityEngine;
using UnityEngine.InputSystem;

public class MoverConInputAction : MonoBehaviour
{
    [SerializeField]
    private InputAction accionMover; // En las 4 direcciones

    [SerializeField]
    private InputAction accionSaltar; // Para saltar, con espacio

    private float velocidadX = 7f;
    private float velocidadY = 8f;
    private Rigidbody2D rb; // Para saltar y caminar
    private EstadoPersonaje estado;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Habilitar el InputAction
        accionMover.Enable();
        rb = GetComponent<Rigidbody2D>(); 
        estado = GetComponentInChildren<EstadoPersonaje>();
    }
    
    void OnEnable() // Añadir la función de saltar
    {
        accionSaltar.Enable();
        accionSaltar.performed += saltar; // Suscribirse al evento performed del InputAction para ejecutar la función saltar cuando se active la acción de salto
    }

    void OnDisable() // Quitar la función de saltar
    {
        accionSaltar.Disable();
        accionSaltar.performed -= saltar; // Desuscribirse del evento performed del InputAction para evitar que la función saltar se ejecute cuando el objeto esté deshabilitado
    }

    public void saltar(InputAction.CallbackContext context)
    {
        if (estado != null && estado.estaEnPiso)
        {
            rb.linearVelocityY = velocidadY * 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Leer la entrada
        Vector2 movimiento = accionMover.ReadValue<Vector2>();
        // transform.position = (Vector2)transform.position + Time.deltaTime * velocidadX * movimiento; // (Vector2) para convertir la posición de vector3 a vector2, ya que solo nos interesa el movimiento en el plano XY
        rb.linearVelocityX = velocidadX * movimiento.x; // Asignar la velocidad de movimiento horizontal al componente Rigidbody2D del objeto para que el personaje se mueva en el plano XY
    }
}

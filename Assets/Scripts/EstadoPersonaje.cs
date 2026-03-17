using UnityEngine;

public class EstadoPersonaje : MonoBehaviour
{
    public bool estaEnPiso {get; private set;} = false; // Variable para verificar si el personaje está en el piso

    void Start()
    {
        print("Inicia EstadoPersonaje");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        estaEnPiso = true;
        print(estaEnPiso);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        estaEnPiso = false;
        print(estaEnPiso);
    }
}

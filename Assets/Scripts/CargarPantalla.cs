using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarPantalla
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void IrAlMenuAlPrincipio()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
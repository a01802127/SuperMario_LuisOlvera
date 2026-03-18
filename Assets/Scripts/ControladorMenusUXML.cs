using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ControladorMenusUXML : MonoBehaviour
{
    private VisualElement menuPrincipal;
    private VisualElement menuAyuda;
    private VisualElement menuCreditos;
    private VisualElement textoDeslizante;

    private bool moviendoCreditos = false;
    private float posicionActualY = 500f;
    private float posicionInicialY = 500f;
    private float velocidad = 2f;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        menuPrincipal = root.Q<VisualElement>("Menu");
        menuAyuda = root.Q<VisualElement>("MenuAyuda");
        menuCreditos = root.Q<VisualElement>("MenuCreditos");
        textoDeslizante = root.Q<VisualElement>("texto-deslizante");

        Button btnJugar = root.Q<Button>("jugar");
        Button btnAyuda = root.Q<Button>("ayuda");
        Button btnCreditos = root.Q<Button>("creditos");

        // Botones para regresar al menú principal
        Button btnAtrasAyuda = menuAyuda.Q<Button>("boton-atras");
        Button btnAtrasCreditos = menuCreditos.Q<Button>("boton-atras");

        // Botones para cerrar la simulación
        Button btnCerrarMenu = menuPrincipal.Q<Button>("boton-cerrar");
        Button btnCerrarAyuda = menuAyuda.Q<Button>("boton-cerrar");

        if (btnJugar != null) btnJugar.clicked += () => SceneManager.LoadScene("SampleScene");

        if (btnAyuda != null)
        {
            btnAyuda.clicked += () => {
                menuPrincipal.style.display = DisplayStyle.None;
                menuAyuda.style.display = DisplayStyle.Flex;
            };
        }

        if (btnCreditos != null)
        {
            btnCreditos.clicked += () => {
                menuPrincipal.style.display = DisplayStyle.None;
                menuCreditos.style.display = DisplayStyle.Flex;
                ReiniciarAnimacion();
                moviendoCreditos = true;
            };
        }

        if (btnAtrasAyuda != null)
        {
            btnAtrasAyuda.clicked += () => {
                menuAyuda.style.display = DisplayStyle.None;
                menuPrincipal.style.display = DisplayStyle.Flex;
            };
        }

        if (btnAtrasCreditos != null)
        {
            btnAtrasCreditos.clicked += () => {
                menuCreditos.style.display = DisplayStyle.None;
                menuPrincipal.style.display = DisplayStyle.Flex;
                moviendoCreditos = false;
            };
        }

        // Asignar función de salida a ambos botones de cerrar
        if (btnCerrarMenu != null) btnCerrarMenu.clicked += SalirDelJuego;
        if (btnCerrarAyuda != null) btnCerrarAyuda.clicked += SalirDelJuego;
    }

    void SalirDelJuego()
    {
        // Esto cierra el juego en el archivo .exe ya construido
        Application.Quit();

        // Esto detiene la reproducción si estás dentro del editor de Unity
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void Update()
    {
        if (moviendoCreditos && textoDeslizante != null)
        {
            posicionActualY -= velocidad;
            float altoTexto = float.IsNaN(textoDeslizante.layout.height) ? 1000f : textoDeslizante.layout.height;

            if (posicionActualY < -altoTexto)
            {
                posicionActualY = posicionInicialY;
            }

            textoDeslizante.style.top = posicionActualY;
        }
    }

    void ReiniciarAnimacion()
    {
        if (textoDeslizante != null)
        {
            posicionActualY = posicionInicialY;
            textoDeslizante.style.top = posicionActualY;
        }
    }
}
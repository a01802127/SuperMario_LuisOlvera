using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class RegresarAlMenu : MonoBehaviour
{
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button btnMenu = root.Q<Button>("boton-menu");

        if (btnMenu != null)
        {
            btnMenu.clicked += () => SceneManager.LoadScene("Menu");
        }
    }
}
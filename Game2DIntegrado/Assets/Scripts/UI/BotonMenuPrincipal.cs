using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonMenuPrincipal : MonoBehaviour
{
    public Button botonMenu;  // Asegúrate de asignar el botón en el Inspector de Unity.

    void Start()
    {
        // Si el botón no está asignado, se muestra un error
        if (botonMenu != null)
        {
            botonMenu.onClick.AddListener(SceneChanger); // Asocia el evento al botón
        }
        else
        {
            Debug.LogError("El botón no está asignado en el Inspector");
        }
    }

    void SceneChanger()
    {
        // Cambiar a la escena principal (asegúrate de que "MainMenu" está bien escrito en tu Build Settings)
        SceneManager.LoadScene("Main Menu");
    }
}
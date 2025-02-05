using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonMenuPrincipal : MonoBehaviour
{
    public Button botonMenu;  // Aseg�rate de asignar el bot�n en el Inspector de Unity.

    void Start()
    {
        // Si el bot�n no est� asignado, se muestra un error
        if (botonMenu != null)
        {
            botonMenu.onClick.AddListener(SceneChanger); // Asocia el evento al bot�n
        }
        else
        {
            Debug.LogError("El bot�n no est� asignado en el Inspector");
        }
    }

    void SceneChanger()
    {
        // Cambiar a la escena principal (aseg�rate de que "MainMenu" est� bien escrito en tu Build Settings)
        SceneManager.LoadScene("Main Menu");
    }
}
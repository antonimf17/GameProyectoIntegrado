using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonMenuPrincipal : MonoBehaviour
{
    public Button botonMenu;  // Asegúrate de asignar el botón en el Inspector de Unity.
    public GameObject PanelOpciones;
    public GameObject PanelMenu;

    void Start()
    {
        // Asegurarnos de que el botón está correctamente asignado en el Inspector
        if (botonMenu != null)
        {
            botonMenu.onClick.AddListener(SceneChanger); // Asocia el evento al botón
        }
        else
        {
            Debug.LogError("El botón no está asignado en el Inspector.");
        }
    }

    // Método para cambiar de escena cuando se presiona el botón
    void SceneChanger()
    {
        // Cambiar a la escena principal (asegúrate de que "Main Menu" está bien escrito en tu Build Settings)
        SceneManager.LoadScene("Main Menu");
        PanelOpciones.SetActive(false);
        PanelMenu.SetActive(true);

    }
}

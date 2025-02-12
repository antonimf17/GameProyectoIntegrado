using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonMenuPrincipal : MonoBehaviour
{
    public Button botonMenu;  // Aseg�rate de asignar el bot�n en el Inspector de Unity.
    public GameObject PanelOpciones;
    public GameObject PanelMenu;

    void Start()
    {
        // Asegurarnos de que el bot�n est� correctamente asignado en el Inspector
        if (botonMenu != null)
        {
            botonMenu.onClick.AddListener(SceneChanger); // Asocia el evento al bot�n
        }
        else
        {
            Debug.LogError("El bot�n no est� asignado en el Inspector.");
        }
    }

    // M�todo para cambiar de escena cuando se presiona el bot�n
    void SceneChanger()
    {
        // Cambiar a la escena principal (aseg�rate de que "Main Menu" est� bien escrito en tu Build Settings)
        SceneManager.LoadScene("Main Menu");
        PanelOpciones.SetActive(false);
        PanelMenu.SetActive(true);
        OpcionesManager.instancia.GameOver.SetActive(false);


    }
}

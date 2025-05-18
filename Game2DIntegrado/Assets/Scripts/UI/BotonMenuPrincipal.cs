using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonMenuPrincipal : MonoBehaviour
{
    #region Referencias
    [Header("Referencias a paneles")]
   [SerializeField] Button botonMenu;  // Asegúrate de asignar el botón en el Inspector de Unity.
   [SerializeField] GameObject PanelOpciones;
   [SerializeField] GameObject PanelMenu;
    #endregion
    #region Start
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
    #endregion
    #region cambiodeescena
    void SceneChanger()
    {
        // Cambiar a la escena principal (asegúrate de que "Main Menu" está bien escrito en tu Build Settings)
        SceneManager.LoadScene("Main Menu");
        PanelOpciones.SetActive(false);
        PanelMenu.SetActive(true);
        OpcionesManager.instancia.GameOver.SetActive(false);
        OpcionesManager.instancia.WingPanel.SetActive(false);
        OpcionesManager.instancia.UIGame.SetActive(false);

    }
    #endregion
}

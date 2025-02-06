using UnityEngine;

public class BotonMenuInicio : MonoBehaviour
{
    public GameObject panelEscena;  // Panel que está en la escena actual
    public GameObject panelDontDestroy;  // Panel dentro de DontDestroyOnLoad
    private bool panelEscenaActivo = false;  // Bool para controlar el estado del panelEscena

    void Start()
    {
        // Inicialmente configuramos ambos paneles de acuerdo con el estado del bool
        panelEscena.SetActive(panelEscenaActivo);  // Si panelEscenaActivo es false, el panelEscena estará desactivado
        panelDontDestroy.SetActive(!panelEscenaActivo);  // El panelDontDestroy estará activo si el panelEscena está desactivado
    }

    // Este método se ejecuta cuando se hace clic en el botón
    public void OnClickTogglePanels()
    {
        // Alternamos el estado del panelEscena
        panelEscenaActivo = !panelEscenaActivo;  // Si estaba en false, lo ponemos en true, y viceversa

        // Activamos o desactivamos los paneles según el nuevo valor del bool
        panelEscena.SetActive(panelEscenaActivo);  // Si el bool es true, el panelEscena se activa
        panelDontDestroy.SetActive(!panelEscenaActivo);  // Si el bool es true, el panelDontDestroy se desactiva
    }
}

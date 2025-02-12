using UnityEngine;

public class BotonMenuInicio : MonoBehaviour
{
    public GameObject panelEscena;  // Panel que est� en la escena actual
    public GameObject panelDontDestroy;  // Panel dentro de DontDestroyOnLoad
    private bool panelEscenaActivo = false;  // Bool para controlar el estado del panelEscena

    void Start()
    {
        // Inicialmente configuramos ambos paneles de acuerdo con el estado del bool
        panelEscena.SetActive(panelEscenaActivo);  // Si panelEscenaActivo es false, el panelEscena estar� desactivado
        panelDontDestroy.SetActive(!panelEscenaActivo);  // El panelDontDestroy estar� activo si el panelEscena est� desactivado
    }

    // Este m�todo se ejecuta cuando se hace clic en el bot�n
    public void OnClickTogglePanels()
    {
        // Alternamos el estado del panelEscena
        panelEscenaActivo = !panelEscenaActivo;  // Si estaba en false, lo ponemos en true, y viceversa

        // Activamos o desactivamos los paneles seg�n el nuevo valor del bool
        panelEscena.SetActive(panelEscenaActivo);  // Si el bool es true, el panelEscena se activa
        panelDontDestroy.SetActive(!panelEscenaActivo);  // Si el bool es true, el panelDontDestroy se desactiva
    }
}

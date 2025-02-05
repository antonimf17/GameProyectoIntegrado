using UnityEngine;

public class OpcionesManager : MonoBehaviour
{
    public static OpcionesManager instancia;
    public GameObject panelOpciones; // Asigna el Panel en el Inspector

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // Mantiene el panel al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Evita duplicados
        }
    }

    public void AlternarPanel()
    {
        if (panelOpciones != null)
        {
            bool estaActivo = !panelOpciones.activeSelf; // Alternar estado
            panelOpciones.SetActive(estaActivo);

            // Pausar o reanudar el tiempo
            Time.timeScale = estaActivo ? 0 : 1;

            Debug.Log("Panel " + (estaActivo ? "Activado (Tiempo Pausado)" : "Desactivado (Tiempo Reanudado)"));
        }
    }
}


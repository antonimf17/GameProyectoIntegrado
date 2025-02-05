using UnityEngine;
using UnityEngine.UI;

public class BotonOpciones : MonoBehaviour
{
    private OpcionesManager opcionesManager;

    void Start()
    {
        opcionesManager = FindObjectOfType<OpcionesManager>(); // Encuentra OpcionesManager en la escena

        if (opcionesManager == null)
        {
            Debug.LogError("No se encontró OpcionesManager en la escena.");
        }

        GetComponent<Button>().onClick.AddListener(ToggleOpciones);
    }

    void ToggleOpciones()
    {
        if (opcionesManager != null)
        {
            opcionesManager.AlternarPanel();
        }
    }
}

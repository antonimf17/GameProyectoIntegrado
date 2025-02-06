using UnityEngine;

public class BotonPausa : MonoBehaviour
{


    public void Opciones()
    {
        // Llamamos al GameManager para desactivar el panel de opciones
        OpcionesManager.instancia.AlternarPanel();
    }
}
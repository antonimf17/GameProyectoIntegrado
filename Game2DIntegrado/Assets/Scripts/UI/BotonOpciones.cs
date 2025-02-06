using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonOpciones : MonoBehaviour
{
    public void VolverAlMenu()
    {
        // Llamamos al GameManager para volver al MainMenu
        OpcionesManager.instancia.VolverAlMenu();
    }
}

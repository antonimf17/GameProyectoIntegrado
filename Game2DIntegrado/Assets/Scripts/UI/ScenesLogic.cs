using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesLogic : MonoBehaviour
{
    #region Voids
    private void Awake()
    {
        // Verificar si ya existe un objeto persistente de esta clase
        var DontDestroyScenes = FindObjectsOfType<ScenesLogic>();

        // Si ya hay otro objeto persistente, destr�yete a ti mismo
        if (DontDestroyScenes.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }

        // Marcar este objeto para que no se destruya al cargar una nueva escena
        DontDestroyOnLoad(this.gameObject);
    }

    // Este m�todo puede ser �til si quieres restablecer o cambiar la l�gica del men�
    public void ResetSceneState()
    {
        // Aqu� podr�as agregar l�gica para resetear el estado si es necesario
    }
    #endregion
}



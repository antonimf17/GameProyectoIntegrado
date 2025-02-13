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

        // Si ya hay otro objeto persistente, destrúyete a ti mismo
        if (DontDestroyScenes.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }

        // Marcar este objeto para que no se destruya al cargar una nueva escena
        DontDestroyOnLoad(this.gameObject);
    }

    // Este método puede ser útil si quieres restablecer o cambiar la lógica del menú
    public void ResetSceneState()
    {
        // Aquí podrías agregar lógica para resetear el estado si es necesario
    }
    #endregion
}



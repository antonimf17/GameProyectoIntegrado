using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaJuego : MonoBehaviour
{
    #region CambioEscena
    public void CambiarEscena()
    {
        SceneManager.LoadScene(1);
       
    }
    #endregion
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager Instancia;
    public GameObject MenuPausa;
    void Awake()
    {
        // Aseguramos que solo haya una instancia de OpcionesManager
        if (Instancia == null)
        {
            Instancia = this;
    
        }
        else
        {
            Destroy(gameObject);  // Si ya existe la instancia, destruir el objeto

        }
       
    }
  

}

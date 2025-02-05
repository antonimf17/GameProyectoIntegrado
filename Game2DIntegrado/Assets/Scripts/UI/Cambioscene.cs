using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambioscene : MonoBehaviour
{

    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject Settings;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MostrarOpciones()
    {
        // Desactivar el Main Menu
        MainMenu.SetActive(false);

        // Activar el Panel de Opciones
       Settings.SetActive(true);
    }
    public void VolverAlMenu()
    {
        // Activar el Main Menu
        MainMenu.SetActive(true);

        // Desactivar el Panel de Opciones
       Settings.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambioscene : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject PanelOpciones1;
   

    // Usar una variable estática para mantener la referencia del PanelOpciones
    private static GameObject panelOpciones;

    void Start()
    {
        // Si PanelOpciones está marcado como DontDestroyOnLoad, se asegura de que se mantenga entre escenas
        DontDestroyOnLoad(PanelOpciones1);

        // Asignamos el PanelOpciones a la variable estática para que siempre sea accesible
        if (panelOpciones == null)
        {
            panelOpciones = PanelOpciones1;
        }

        // Inicialmente, se activa el MainMenu y desactiva el PanelOpciones
        MainMenu.SetActive(true);
        PanelOpciones1.SetActive(false);
    }

    void Update()
    {
        // Aquí puedes agregar otras lógicas si es necesario
    }

    // Este método se llama cuando quieres mostrar el panel de Opciones (Settings)
    public void MostrarOpciones()
    {
        MainMenu.SetActive(false);
        panelOpciones.SetActive(true);  // Usamos la referencia estática global
    }

    // Este método se llama para volver al MainMenu desde Settings
    public void VolverAlMenu()
    {
        MainMenu.SetActive(true);
        panelOpciones.SetActive(false);  // Usamos la referencia estática global
    }

    // Este evento se llama cuando se ha cargado una nueva escena
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // En este caso, ya no necesitamos buscar el PanelOpciones, porque usamos la referencia global
        // Si PanelOpciones se marca como DontDestroyOnLoad, ya se mantendrá entre escenas
    }

    // Suscribirse al evento cuando la escena es cargada
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Desuscribirse al evento cuando el objeto se desactive
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

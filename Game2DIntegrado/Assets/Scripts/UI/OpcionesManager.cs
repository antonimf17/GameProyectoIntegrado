using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpcionesManager : MonoBehaviour
{
    public static OpcionesManager instancia;
    public GameObject panelOpciones;  // Panel de opciones a alternar
    public Button botonMenu;          // Botón para menú
    public GameObject MainMenu;       // Panel principal (Main Menu)

    private bool isPaused = false;  // Bandera para saber si el juego está pausado

    void Awake()
    {
        // Aseguramos que solo haya una instancia de OpcionesManager
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);  // No destruir al cambiar de escena
        }
        else
        {
            Destroy(gameObject);  // Si ya existe la instancia, destruir el objeto
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;  // Suscribirse al evento de carga de escena
        ActualizarEstadoBoton();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  // Solo activar opciones con Escape
        {
            AlternarPanel();
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  // Desuscribirse del evento cuando el objeto es destruido
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ActualizarEstadoBoton();  // Llamar a la función cuando se carga una nueva escena
    }

    private void ActualizarEstadoBoton()
    {
        if (botonMenu != null)
        {
            // Activar solo si la escena es "Game1"
            botonMenu.gameObject.SetActive(SceneManager.GetActiveScene().name == "Game1");
        }
    }

    public void AlternarPanel()
    {
        if (panelOpciones == null) return;

        bool estaActivo = !panelOpciones.activeSelf;
        panelOpciones.SetActive(estaActivo);

        // Pausar o reanudar el juego solo cuando el panel cambia de estado
        isPaused = estaActivo;

        // Pausar si el panel está activo, reanudar si no
        Time.timeScale = estaActivo ? 0 : 1;

        Debug.Log("Opciones " + (estaActivo ? "activadas (pausa)" : "cerradas (reanudar)"));
    }

    public void VolverAlMenu()
    {
        MainMenu.SetActive(true);
        panelOpciones.SetActive(false);
    }

    public void CambiarEscenaMenuPrincipal()
    {
        SceneManager.LoadScene("Main Menu");  // Cambiar a la escena "Main Menu"
    }
}

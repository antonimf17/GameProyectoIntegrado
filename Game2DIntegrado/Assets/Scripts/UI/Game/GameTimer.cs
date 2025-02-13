using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public static GameTimer instance;
    public TextMeshProUGUI timerText;

    private float timeElapsed = 0f;
    private bool isRunning = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (GameTimer.instance != null)
        {
            GameTimer.instance.StartTimer();
        }
    }


    void Update()
    {
        if (isRunning)
        {
            timeElapsed += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        int milliseconds = Mathf.FloorToInt((timeElapsed * 10) % 10);

        if (timerText != null)
        {
            timerText.text = string.Format("{0:00}:{1:00}:{2:0}", minutes, seconds, milliseconds);
        }

        else
        {
            Debug.LogError("No se ha agregado el TextMeshPro del timer en GameTimer");
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game1")
        {
            ResetTimer();
            StartTimer();
        }
        else if (scene.name == "Main Menu")
        {
            StopTimer();
        }
    }

    public void StartTimer()
    {
        timeElapsed = 0f;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        timeElapsed = 0f;
        isRunning = false;
        UpdateTimerDisplay();
    }


    public float GetElapsedTime()
    {
        return timeElapsed;
    }
}

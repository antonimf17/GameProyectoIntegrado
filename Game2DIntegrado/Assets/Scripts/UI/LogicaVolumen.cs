using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaVolumen : MonoBehaviour
{
    #region Referencias volumen
    [Header("ReferenciasVolumen")]
    [SerializeField] Slider slider;
    [SerializeField] float sliderValue;
    [SerializeField] Image imagenMute;
    #endregion
    #region Start
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }
    #endregion
    #region void
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }

    public void RevisarSiEstoyMute()
    {
        if (slider.value == 0)
        {
            imagenMute.enabled = true;

        }
        else
        {
            imagenMute.enabled = false;
        }
    }
    #endregion
}



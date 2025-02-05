using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaBrillo : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image panelBrillo;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Brillo", 0.5f);
        sliderValue = slider.value;
        ActualizarBrillo();
    }

    void Update()
    {
        sliderValue = slider.value;
        ActualizarBrillo();
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("Brillo", sliderValue);
        ActualizarBrillo();
    }

    void ActualizarBrillo()
    {
        float nuevoAlfa = Mathf.Clamp(Mathf.Abs(sliderValue - 0.5f) * 1.8f, 0.02f, 0.78f);
        // 🔹 Alfa mínimo: 0.02 (para que nunca sea completamente opaco)
        // 🔹 Alfa máximo: 0.78 (equivalente a 200 en escala de 255)

        if (sliderValue < 0.5f)
        {
            panelBrillo.color = new Color(0, 0, 0, nuevoAlfa); // Llega a 200 (0.78 en Unity)
        }
        else
        {
            panelBrillo.color = new Color(1, 1, 1, nuevoAlfa); // Ajusta el blanco también
        }
    }
}
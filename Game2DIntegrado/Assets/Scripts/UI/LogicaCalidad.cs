using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicaCalidad : MonoBehaviour
{
    #region Referencias
    [Header("Referencias calidad")]
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] int quality;
    #endregion
    #region start
    void Start()
    {
        quality = PlayerPrefs.GetInt("numeroDeCalidad", 3);
        dropdown.value = quality;
        AdjustQuality();
    }
    #endregion
    #region void
    public void AdjustQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroDeCalidad", dropdown.value);
        quality = dropdown.value;
    }
    #endregion
}


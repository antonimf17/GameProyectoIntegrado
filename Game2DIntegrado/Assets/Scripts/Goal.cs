using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OpcionesManager.instancia.WingPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }


}

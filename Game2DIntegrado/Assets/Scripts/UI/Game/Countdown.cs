using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    public int countdownTime;
    public TMP_Text countdownDisplay;

    private void Start()
    {
        StartCoroutine(CountDownToStart());
    }

    IEnumerator CountDownToStart()
    {
        while(countdownTime > 0)
        {
            Time.timeScale = 0;
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSecondsRealtime(1f);

            countdownTime--;
        }
        countdownDisplay.text = "GO!";
        Time.timeScale = 1;
     


       yield return new WaitForSecondsRealtime(1f);
        countdownDisplay.gameObject.SetActive(false);
        Manager.Instancia.pausa.SetActive(true);

       

    }


}

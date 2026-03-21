using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endscreenManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text display;
    String DaysSurvivedParam = "LastDaySurvived";

    void OnEnable()
    {
        SceneManager.sceneLoaded += UpdateDisplay;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= UpdateDisplay;
    }

    void UpdateDisplay(Scene scene, LoadSceneMode loadSceneMode)
    {
        int daysSurvived = PlayerPrefs.GetInt(DaysSurvivedParam);
        display.text = "Days survived: " + daysSurvived.ToString("D2");

    }

     
}

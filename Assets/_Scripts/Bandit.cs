using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bandit : MonoBehaviour
{
    [SerializeField]
    String rentText, endScreenSceneName;
    int currentDay = 0;
    [SerializeField]
    TMP_Text dialogue;
    String lastDaySurvivedParam = "LastDaySurvived";
    [SerializeField] CanvasGroup canvasGroup;


    void Start()
    {
        Clock.instance.dayEndEvent.AddListener(Display);
        CloseBanditMenu();
    }
    public void Display()
    {
        Clock.instance.paused = true;
        ShowBanditMenu();
        dialogue.text = rentText + CalculateRent() + " coins.";

    }
    int CalculateRent()
    {
        return CalculateFibonnaci(currentDay + 1) * 100;
    }
    public  void CalculateEndOfDay()
    {
        int rent = CalculateRent();
        if(GameManager.instance.GetCoins() >= rent)
        {
            GameManager.instance.RemoveCoins(rent);
            CloseBanditMenu();
            Clock.instance.paused = false;
            currentDay++;
        }
        else
        {
            SaveScore();    
            SceneManager.LoadScene(endScreenSceneName);
        }
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt(lastDaySurvivedParam, currentDay);
        PlayerPrefs.Save();
    }
    void ShowBanditMenu()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
    void CloseBanditMenu()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }
    int CalculateFibonnaci(int m)
    {
        int[] T = new int[m + 1];
        int i;
        if (m == 0){
            return 0;
        }
        else {
            if (m == 1) {
                return 1;
            } else {
                T[0] = 0;
                T[1] = 1;
                for (i = 2; i <=m; i++) {
                    T[i] = T[i - 2] + T[i - 1];
                }
                return T[m];
            }
        }
    }

}



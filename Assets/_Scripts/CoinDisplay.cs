using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField]
    TMP_Text textDisplay;
    void Start()
    {
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        textDisplay.text = GameManager.instance.GetCoins().ToString("D4");
    }
}

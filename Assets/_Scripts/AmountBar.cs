using System.Net.NetworkInformation;
using System.Security.Cryptography;
using UnityEngine;

public class AmountBar : MonoBehaviour
{
    float proportion;
    [SerializeField]
    Transform colorBar;
    void UpdateDisplay()
    {
        float scale = proportion * 2;
        colorBar.localScale = new Vector3(1, scale, 1);
    } 

    public void SetProportion(float input)
    {
        proportion = input;
        UpdateDisplay();
    }
}

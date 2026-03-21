using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] CoinDisplay coinDisplay;
    [SerializeField]

    int coins;
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        coinDisplay.UpdateDisplay();
    }

    public int GetCoins()
    {
        return coins;
    }

    public void RemoveCoins(int amount)
    {
        coins -= amount;
        coinDisplay.UpdateDisplay();        
    }
}

    using TMPro;
using UnityEngine;

public class SeedPurchaseable : MonoBehaviour
{
    [SerializeField] int cost;
    [SerializeField] PlantType plantType;
    [SerializeField] TMP_Text CostDisplay;
    [SerializeField] AudioClip buySound, cancelSound;
    void Start()
    {
        CostDisplay.text = cost.ToString("D3");
    }
    public void PurchaseSeed()
    {
        if(GameManager.instance.GetCoins() >= cost)
        {
            GameManager.instance.RemoveCoins(cost);
            Inventory.instance.AddSeed(plantType);
            AudioOneShotManager.PlayOneShot(buySound);
        }
        else AudioOneShotManager.PlayOneShot(cancelSound);

    }
}

using UnityEngine;

public class CropSeller : MonoBehaviour
{
    public void SellCrops()
    {
        GameObject inventory = Inventory.instance.GetInventoryHolder();

        Crop[] crops = inventory.GetComponentsInChildren<Crop>();
        foreach(Crop crop in crops)
        {
            int value = crop.amount * crop.GetValue();
            GameManager.instance.AddCoins(value);
            Destroy(crop.gameObject);
        }
    }
}

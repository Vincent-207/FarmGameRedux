using UnityEngine;

public class CropSeller : MonoBehaviour
{
    public AudioClip sellSound, cancelSound;
    public void SellCrops()
    {
        GameObject inventory = Inventory.instance.GetInventoryHolder();

        Crop[] crops = inventory.GetComponentsInChildren<Crop>();
        bool hasCrops = crops != null && crops.Length > 0;
        foreach(Crop crop in crops)
        {
            int value = crop.amount * crop.GetValue();
            GameManager.instance.AddCoins(value);
            Destroy(crop.gameObject);
        }

        if(hasCrops) AudioOneShotManager.PlayOneShot(sellSound);
        else AudioOneShotManager.PlayOneShot(cancelSound);

        
    }
}

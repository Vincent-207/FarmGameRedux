using UnityEngine;

public class HandScythe : Item
{
    public override bool IsItemUseable(Vector2Int gridPos)
    {
        // Debug.Log("checking usabel!");
        bool IsInGrid =  base.IsItemUseable(gridPos);
        if(!IsInGrid) return false;
        // Debug.Log("Is in grid");

        Plant plant = GridManager.instance.GetPlant(gridPos);
        if(plant == null) return false;
        // Debug.Log("Plant exists");

        if(plant.isHarvestable()) return true;
        // Debug.Log("Plant is not harvestable");

        return false;
    }

    public override void ConsumeItem(Vector2Int gridPos)
    {
        // Debug.Log("Starting harvest");
        // Harvest item
        Plant plant = GridManager.instance.GetPlant(gridPos);
        // Debug.Log("got plant");
        Inventory.instance.AddCrop(plant.GetPlantType());
        // Debug.Log("Added crop");
        Destroy(plant.gameObject);
        // Debug.Log("destroyed plant");
        PlayUseSound();
    }
    internal override void UpdateAmountText()
    {
        
    }
}

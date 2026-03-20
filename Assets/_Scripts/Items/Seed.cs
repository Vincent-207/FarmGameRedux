using UnityEngine;

public class Seed : Item
{
    [SerializeField] PlantType plantType;
    [SerializeField] GameObject PlantPrefab;
    public override void ConsumeItem(Vector2Int gridPos)
    {
        Plant plant = Instantiate(PlantPrefab, new Vector3(gridPos.x, gridPos.y), Quaternion.identity, GridManager.instance.transform).GetComponent<Plant>();
        GridManager.instance.AddPlant(gridPos, plant);
        base.ConsumeItem(gridPos);
    }

    public override bool IsItemUseable(Vector2Int gridPos)
    {
        bool IsInGrid = base.IsItemUseable(gridPos);
        if(!IsInGrid) return false;

        Plant plant = GridManager.instance.GetPlant(gridPos);
        if(plant != null) return false;

        return true;

    }
}




public enum PlantType
{
    wheat, 
    carrot,
}

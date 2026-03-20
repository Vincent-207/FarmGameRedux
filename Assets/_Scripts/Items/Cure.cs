using UnityEngine;

public class Cure : Item
{
    [SerializeField]
    Disease cureType;
    public override void ConsumeItem(Vector2Int gridPos)
    {
        Plant plant = GridManager.instance.GetPlant(gridPos);
        
        plant.Cure(cureType);
        base.ConsumeItem(gridPos);
    }
    public override bool IsItemUseable(Vector2Int gridPos)
    {
        bool IsInGrid =  base.IsItemUseable(gridPos);
        if(!IsInGrid) return false;
        Plant plant = GridManager.instance.GetPlant(gridPos);
        if(plant == null ) return false;
        if(plant.GetDisease() == cureType) return true;
        return false;
    }
}

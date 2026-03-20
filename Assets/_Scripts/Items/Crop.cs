using UnityEngine;

public class Crop : Item
{
    [SerializeField]
    PlantType cropType;

    public bool IsCropOfType(PlantType inputType)
    {
        return cropType == inputType;
    }
    public override bool IsItemUseable(Vector2Int gridPos)
    {
        return false;
    }
}

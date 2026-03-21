using UnityEngine;

public class Crop : Item
{
    [SerializeField]
    
    int value;
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
    public int GetValue()
    {
        return value;
    }
}

using UnityEngine;

public class Crop : Item
{
    [SerializeField]
    PlantType cropType;

    public bool IsCropOfType(PlantType inputType)
    {
        return cropType == inputType;
    }

    public void Increment()
    {
        amount++;
        UpdateAmountText();
    }
}

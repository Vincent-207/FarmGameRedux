using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField]
    Item currentSelectedItem;
    [SerializeField] GameObject[] cropPrefabs;
    [SerializeField] GameObject[] curePrefabs;
    [SerializeField] GameObject[] seedPrefabs;
    [SerializeField] GameObject inventoryHolder;

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public void SelectItem(Item item)
    {
        if(currentSelectedItem != null) currentSelectedItem.DeselectItem();
        currentSelectedItem = item;
        item.SelectItem();
        
    }

    public void DeselectItem()
    {
        currentSelectedItem.DeselectItem();
        currentSelectedItem = null;
    }

    public Item GetCurrentItem()
    {
        return currentSelectedItem;
    }

    public void AddCrop(PlantType cropType)
    {
        Debug.Log("IMPLEMENT!");
        Crop[] crops = inventoryHolder.GetComponentsInChildren<Crop>();
        foreach(Crop crop in crops)
        {
            if(crop.IsCropOfType(cropType))
            {
                Debug.Log("Found crop, incrementing!");
                crop.Increment();
                return;
            }
        }

        // No matching crop items, need to instantiate new one.
        Debug.Log("Instantiating new crop!");
        Crop newCrop = Instantiate(cropPrefabs[(int) cropType], inventoryHolder.transform).GetComponent<Crop>();
        newCrop.amount = 1;
    }

    public void AddCure(Disease diseaseType)
    {
        Cure[] cures = inventoryHolder.GetComponentsInChildren<Cure>();
        foreach(Cure cure in cures)
        {
            Debug.Log("Checking: " + cure.gameObject.name);
            if(cure.isOfCureType(diseaseType))
            {
                cure.Increment();
                return;
            }
        }
        Cure newCure = Instantiate(curePrefabs[(int) diseaseType], inventoryHolder.transform).GetComponent<Cure>();
        newCure.amount = 1;
    }


    public void AddSeed(PlantType seedType)
    {
        Seed[] seeds = inventoryHolder.GetComponentsInChildren<Seed>();
        foreach(Seed seed in seeds)
        {
            if(seed.isOfSeedType(seedType))
            {
                seed.Increment();
                return;
            }
        }

        Seed newSeed = Instantiate(seedPrefabs[(int) seedType], inventoryHolder.transform).GetComponent<Seed>();
        newSeed.amount = 1;
    }


}

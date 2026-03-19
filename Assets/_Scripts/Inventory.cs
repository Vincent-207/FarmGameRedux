using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField]
    Item currentSelectedItem;
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
}

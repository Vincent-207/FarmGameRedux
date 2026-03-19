using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerClickHandler
{
    Image hoverBackground;
    void Start()
    {
        hoverBackground = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Entered!");
        Inventory.instance.SelectItem(this);
    }

    public void SelectItem()
    {
        hoverBackground.enabled = true;
    }

    public void DeselectItem()
    {
        hoverBackground.enabled = false;
    }
}

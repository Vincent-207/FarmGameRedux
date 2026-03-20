using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerClickHandler
{
    Image hoverBackground;
    [SerializeField] internal int amount;
    [SerializeField] TMP_Text amountText;
    void Start()
    {
        hoverBackground = GetComponent<Image>();
        UpdateAmountText();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log("Entered!");
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

    public virtual bool IsItemUseable(Vector2Int gridPos)
    {
        bool IsInGrid = GridManager.instance.IsInGrid(gridPos);
        // Debug.Log("ItemIsEvalating: " + IsInGrid);
        return IsInGrid;
    }

    public virtual void ConsumeItem(Vector2Int gridPos)
    {
        // Do item use stuff.

        DecrementAmount();

    }

    void DecrementAmount()
    {
        amount--;
        if(amount <= 0)
        {
            Inventory.instance.DeselectItem();
            Destroy(this.gameObject);
            return;
        }

        UpdateAmountText();
    }

    internal virtual void UpdateAmountText()
    {
        amountText.text = "x" + amount.ToString("D2");
    }
}

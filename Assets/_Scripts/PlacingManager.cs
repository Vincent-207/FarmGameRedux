using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlacingManager : MonoBehaviour
{
    [SerializeField] Transform hoverIcon;
    Rigidbody2D rb;
    Vector2 offset;
    [SerializeField]
    InputActionReference place;
    void OnEnable()
    {
        place.action.started += UseItem;

    }
    void OnDisable()
    {
        place.action.started -= UseItem;
    }
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
    void Update()
    {
        UpdateOffset();
    }

    void UpdateOffset()
    {
        Vector2 velocity = rb.linearVelocity.normalized;
        if(velocity == Vector2.right) offset = Vector2.right;
        else if(velocity == -Vector2.right) offset = -Vector2.right;
        else if(velocity == Vector2.up) offset = Vector2.up * 2;
        else if(velocity == -Vector2.up) offset =  -Vector2.up;
        // Debug.Log("Velocity : " + velocity);
        hoverIcon.localPosition = offset;

        // snap to planting grid
        Vector3Int gridPos = Vector3Int.FloorToInt(hoverIcon.position + new Vector3(0.5f, 0f));
        hoverIcon.position = gridPos;
    }

    void UseItem(InputAction.CallbackContext context)
    {
        Item currentItem = Inventory.instance.GetCurrentItem();
        // if(currentItem == null) Debug.Log("Current item is null!");
        if(currentItem == null) return;
        Vector2Int hoveredPos = Vector2Int.CeilToInt(hoverIcon.position);
        if(currentItem.IsItemUseable(hoveredPos))
        {
            currentItem.ConsumeItem(hoveredPos);

        }
    }
}

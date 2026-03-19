using UnityEngine;
using UnityEngine.Rendering;

public class PlacingManager : MonoBehaviour
{
    public Transform hoverIcon;
    Rigidbody2D rb;
    Vector2 offset;
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
        Vector3Int gridPos = Vector3Int.FloorToInt(hoverIcon.position);
        hoverIcon.position = gridPos;
    }
}

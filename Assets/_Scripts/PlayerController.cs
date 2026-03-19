using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    InputActionReference moveInput;
    Rigidbody2D rb;
    public float moveSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 move = moveInput.action.ReadValue<Vector2>();
        rb.linearVelocity = move * moveSpeed;
    }
}

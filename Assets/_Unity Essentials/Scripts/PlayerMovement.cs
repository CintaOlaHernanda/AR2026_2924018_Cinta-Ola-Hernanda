using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody rb;
    private Vector2 movementInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Fungsi ini otomatis terpanggil oleh StarterAssets dengan Behavior: Send Messages
    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(movementInput.x, 0f, movementInput.y).normalized;
        Vector3 nextPosition = rb.position + direction * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(nextPosition);
    }
}
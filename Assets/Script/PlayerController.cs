using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpPower = 5;

    [SerializeField] private Rigidbody2D rb;

    private void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(new Vector2(0, jumpPower));
        }
    }
}

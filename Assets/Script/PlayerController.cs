using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 5;
    public float jumpPower = 5;

    public bool onGround;

    public Vector2 respawnPoint;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject traps;

    private void Start() {
        respawnPoint = transform.position;
    }

    private void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        if (onGround && Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(new Vector2(0, jumpPower));
        }


        if (transform.position.y <= -4) {
            Respawn();
        }
    }

    public void Respawn() {
        transform.position = respawnPoint;

        foreach (Trigger trigger in traps.GetComponentsInChildren<Trigger>()) {
            trigger.ResetTrap();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        onGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        onGround = false;
    }
}

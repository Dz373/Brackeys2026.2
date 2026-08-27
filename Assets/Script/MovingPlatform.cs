using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Vector2[] path;
    public bool loop;

    private int pathIndex = 0;
    private bool moveForward = true;

    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, path[pathIndex], speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, path[pathIndex]) < 0.01f) {
            if(moveForward)
                pathIndex++;
            else
                pathIndex--;
        }

        if (loop && pathIndex >= path.Length) {
            pathIndex = 1;
        }
        else if (moveForward && pathIndex >= path.Length) {
            moveForward = false;
            pathIndex--;
        }
        else if (!moveForward && pathIndex < 0) {
            moveForward = true;
            pathIndex++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.transform.SetParent(null);
        }
    }
}

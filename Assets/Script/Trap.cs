using UnityEngine;

public class Trap : MonoBehaviour
{
    public TrapType type;

    private Vector2 startPos;

    private void Start() {
        startPos = transform.position;
    }

    public void ResetTrap() {
        gameObject.SetActive(true);
        transform.position = startPos;
    }

    public void TriggerTrap() {
        switch (type) {
            case TrapType.disappear:
                gameObject.SetActive(false);
                break;


        }
    }

    public enum TrapType {
        disappear,
        move,
        rotate
    }
}

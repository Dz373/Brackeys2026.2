using UnityEngine;

public class Trap : MonoBehaviour
{
    public TrapType type;

    //Disappear Trap
    [HideInInspector] public float delay;

    //Move Trap
    [HideInInspector] public Vector2 moveTarget;
    [HideInInspector] public float moveSpeed;

    //Rotate Trap
    [HideInInspector] public float rotateAngle;
    [HideInInspector] public float rotateSpeed;

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

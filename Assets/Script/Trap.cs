using UnityEngine;
using System.Collections;

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
    private Quaternion startRot;

    private void Start() {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    public void ResetTrap() {
        gameObject.SetActive(true);
        transform.position = startPos;
        transform.rotation = startRot;
    }

    public void TriggerTrap() {
        switch (type) {
            case TrapType.disappear:
                gameObject.SetActive(false);
                break;

            case TrapType.move:
                StartCoroutine(MoveTrap());
                break;

            case TrapType.rotate:
                StartCoroutine(RotateTrap());
                break;
        }
    }

    private IEnumerator MoveTrap() {
        while (Vector2.Distance(transform.position, moveTarget) > 0.01f) {
            transform.position = Vector2.Lerp(transform.position, moveTarget, moveSpeed * Time.deltaTime); ;
            yield return null;
        }
        transform.position = moveTarget;
    }

    private IEnumerator RotateTrap() {
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0,0,rotateAngle));
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f) {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            yield return null;
        }
        transform.rotation = targetRotation;
    }

    public enum TrapType {
        disappear,
        move,
        rotate
    }
}

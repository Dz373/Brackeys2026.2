using UnityEngine;

public class Trap : MonoBehaviour
{
    public virtual void ResetTrap() {
        Debug.Log("Reset");
    }

    public virtual void TriggerTrap() {
        Debug.Log("Trigger");
    }
}

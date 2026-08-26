using UnityEngine;

public class PitTrap : Trap
{
    public override void TriggerTrap() {
        gameObject.SetActive(false);
    }

    public override void ResetTrap() {
        gameObject.SetActive(true);
    }
}

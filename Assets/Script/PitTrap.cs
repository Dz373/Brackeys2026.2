using UnityEngine;

public class PitTrap : Trap
{
    public override void TriggerTrap() {
        Destroy(gameObject);
    }
}

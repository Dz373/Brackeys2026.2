using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool triggered = false;
    public Trap trap;

    

    private void OnTriggerEnter2D(Collider2D collision) {
        if(trap != null && !triggered)
            trap.TriggerTrap();

        triggered = true;
    }
}

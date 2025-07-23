using UnityEngine;

public class HitEvent : MonoBehaviour
{
    public EnemyFSM efsm;

    public void PlayHit()
    {
        efsm.AttackAction();
    }
}

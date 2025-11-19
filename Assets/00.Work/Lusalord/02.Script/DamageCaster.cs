using System;
using _00.Work.Lusalord._02.Script.Player;
using _00.Work.Lusalord._02.Script.Player.Attack;
using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    public PlayerHandleAttack attackHandler;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(!attackHandler.IsAttacking)
            return;
        // 적이 HealthSystem을 가지고 있다면 데미지 적용
        HealthSystem hp = other.GetComponentInChildren<HealthSystem>();
        if (hp != null)
        {
            Debug.Log("Hit");
            attackHandler.OnHit(hp);
        }
    }
}

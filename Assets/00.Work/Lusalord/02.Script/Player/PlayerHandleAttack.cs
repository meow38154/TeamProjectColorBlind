using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Player
{
    public class PlayerHandleAttack : MonoBehaviour
    {
        [SerializeField] private DamageCaster damageCaster;
        [SerializeField] private int damage;

        public void OnHit(HealthSystem enemy)
        {
            enemy.GetDamage(damage, enemy.transform);
        }
    }
}
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Player.Attack
{
    public class PlayerHandleAttack : MonoBehaviour
    {
        [SerializeField] private DamageCaster damageCaster;
        [SerializeField] private int damage;
        [SerializeField] private GameObject hitBox;
        
        public bool IsAttacking { get; private set; }
        public void EnableHitBox()
        {
            IsAttacking = true;
            hitBox.SetActive(true);
        }

        public void DisableHitBox()
        {
            IsAttacking = false;
            hitBox.SetActive(false);
        }
        public void OnHit(HealthSystem enemy)
        {
            enemy.GetDamage(damage, enemy.transform);
        }
    }
}
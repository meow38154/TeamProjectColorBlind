using System;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private Player _player;
        [SerializeField] private DamageCaster damageCaster;
        public int damage;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _player.PlayerInput.OnAttackKeyPressed += AttackEnemy;
        }

        private void OnDestroy()
        {
            _player.PlayerInput.OnAttackKeyPressed -= AttackEnemy;
        }

        private void AttackEnemy()
        {
            
            if (damageCaster.CurrentEnemy == null)
            {
                return;
            }
            HealthSystem health = damageCaster.CurrentEnemy.GetComponentInChildren<HealthSystem>();
            health.GetDamage(damage, damageCaster.CurrentEnemy);
        }
    }
}
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.InputSystem;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private bool _boss = true;

    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField, ReadOnly] public int CurrentHealth { get; private set; }

    public Action<int, Transform> OnGetDamage; //����� �Ծ��� �� ȣ��� �׼�
    public Action<int, Transform> OnHealHealth; //ü�� ȸ���� ���� �� ȣ��� �׼�
    public Action OnDie; //�׾��� �� ȣ��� �׼�

    [SerializeField] private float _invincibilityTime = 0;
    private bool _invincibility = false;

    public bool Invincibility { get; set; }


    private void Awake()
    {
        CurrentHealth = MaxHealth; //���� ü���� �ִ�ü������ ����
    }

    public void GetDamage(int damage, Transform transform)
    {
        if (!Invincibility)
        {
            if (!_invincibility)
            {
                if (_boss)
                {
                    InGameManager.Instance.ManaBar.AddHealth(2.5f);
                    SoundManager.Instance.PlaySound(5, 0.2f);
                }

                StartCoroutine(InvincibilityTime());
                CurrentHealth -= damage;
                CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
                if (CurrentHealth > 0) //���� ���� ü���� 0 �ʰ��� ��
                {
                    OnGetDamage?.Invoke(damage, transform);
                }

                else //���� ���� ü���� 0 ������ ��
                {
                    Die(); //�׾��� �� ���Ǵ� �޼��� ȣ��
                }
            }
        }
    }

    public void GetHeal(int heal, Transform transform)
    {
        if (!Invincibility)
        {
            CurrentHealth += heal;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
            OnHealHealth?.Invoke(heal, transform);
        }
    }

    public void Die()
    {
        if (!Invincibility)
        {
            OnDie?.Invoke(); //�׾��� �� ���Ǵ� �׼� ȣ�� (null�̸� ȣ�� ����)
            Debug.Log($"{gameObject} is die");
        }
    }

    private IEnumerator InvincibilityTime()
    {
        _invincibility = true;
        yield return new WaitForSeconds(_invincibilityTime);
        _invincibility = false;
    }
}

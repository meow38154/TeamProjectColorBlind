using UnityEngine;
using System;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField, ReadOnly] public int CurrentHealth { get; private set; }

    public Action<int, Transform> OnGetDamage; //����� �Ծ��� �� ȣ��� �׼�
    public Action<int, Transform> OnHealHealth; //ü�� ȸ���� ���� �� ȣ��� �׼�
    public Action OnDie; //�׾��� �� ȣ��� �׼�

    [SerializeField] private float _invincibilityTime = 0;
    private bool _invincibility = false;


    private void Awake()
    {
        CurrentHealth = MaxHealth; //���� ü���� �ִ�ü������ ����
    }

    public void GetDamage(int damage, Transform transform)
    {
        if (!_invincibility)
        {
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

    public void GetHeal(int heal, Transform transform)
    {
        OnHealHealth?.Invoke(heal, transform); //ü���� ȸ������ �� ���Ǵ� �׼� ȣ�� (null�̸� ȣ�� ����)
        CurrentHealth += heal; //���� ���� ��ŭ ü���� ȸ��
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth); //���� ü���� 0~_maxHealth ���̷� �ٲ�R(ü���� �ִ�ü���� �ʰ����� �ʰ�)
    }

    public void Die()
    {
        OnDie?.Invoke(); //�׾��� �� ���Ǵ� �׼� ȣ�� (null�̸� ȣ�� ����)
        Debug.Log($"{gameObject} is die");
    }

    private IEnumerator InvincibilityTime()
    {
        _invincibility = true;
        yield return new WaitForSeconds(_invincibilityTime);
        _invincibility = false;
    }
}

using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public int CurrentHealth { get; private set; }

    public Action<int, Transform> OnGetDamge; //����� �Ծ��� �� ȣ��� �׼�
    public Action<int, Transform> OnHealHealth; //ü�� ȸ���� ���� �� ȣ��� �׼�
    public Action OnDie; //�׾��� �� ȣ��� �׼�


    private void Awake()
    {
        CurrentHealth = MaxHealth; //���� ü���� �ִ�ü������ ����
    }

    public void GetDamage(int damage, Transform transform)
    {
        CurrentHealth -= damage; //���� ü�¿� ���� ����� ��ŭ�� ��
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth); //���� ü���� 0~_maxHealth ���̷� �ٲ�R(ü���� -�� ���� �ʰ�)
        if (CurrentHealth > 0) //���� ���� ü���� 0 �ʰ��� ��
        {
            OnGetDamge?.Invoke(damage, transform); //������� �Ծ��� �� ���Ǵ� �׼� ȣ�� (null�̸� ȣ�� ����)
        }

        else //���� ���� ü���� 0 ������ ��
        {
            Die(); //�׾��� �� ���Ǵ� �޼��� ȣ��
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
}

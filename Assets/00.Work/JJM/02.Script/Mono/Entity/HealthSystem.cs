using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int _maxHealth; 
    [SerializeField] private int _currentHealth;

    public Action<int, Transform> OnGetDamge; //����� �Ծ��� �� ȣ��� �׼�
    public Action<int, Transform> OnHealHealth; //ü�� ȸ���� ���� �� ȣ��� �׼�
    public Action OnDie; //�׾��� �� ȣ��� �׼�


    private void Awake()
    {
        _currentHealth = _maxHealth; //���� ü���� �ִ�ü������ ����
    }

    public void GetDamage(int damage, Transform transform)
    {
        _currentHealth -= damage; //���� ü�¿� ���� ����� ��ŭ�� ��
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth); //���� ü���� 0~_maxHealth ���̷� �ٲ�R(ü���� -�� ���� �ʰ�)
        if (_currentHealth > 0) //���� ���� ü���� 0 �ʰ��� ��
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
        _currentHealth += heal; //���� ���� ��ŭ ü���� ȸ��
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth); //���� ü���� 0~_maxHealth ���̷� �ٲ�R(ü���� �ִ�ü���� �ʰ����� �ʰ�)
    }

    public void Die()
    {
        OnDie?.Invoke(); //�׾��� �� ���Ǵ� �׼� ȣ�� (null�̸� ȣ�� ����)
        Debug.Log($"{gameObject} is die");
    }
}

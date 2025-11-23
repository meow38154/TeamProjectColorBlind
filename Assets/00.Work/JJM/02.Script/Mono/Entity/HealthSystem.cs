using _00.Work.Lusalord._02.Script.Player;
using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private bool _boss = true;
    [SerializeField] private string _scene;
    [field: SerializeField] public int MaxHealth { get; set; }
    [field: SerializeField, ReadOnly] public int CurrentHealth { get; private set; }

    public Action<int, Transform> OnGetDamage; //����� �Ծ��� �� ȣ��� �׼�
    public Action<int, Transform> OnHealHealth; //ü�� ȸ���� ���� �� ȣ��� �׼�
    public Action OnDie; //�׾��� �� ȣ��� �׼�

    [SerializeField] private float _invincibilityTime = 0;
    private bool _invincibility = false;

    public bool Invincibility { get; set; }

    private bool die = false;

    private float _saveX;

    private void Awake()
    {

        CurrentHealth = MaxHealth; //���� ü���� �ִ�ü������ ����
    }

    private void Update()
    {
        if (die && !_boss)
        {
            transform.root.position = new Vector3(_saveX, transform.root.position.y, transform.root.position.z);
        }
    }

    public void GetDamage(int damage, Transform transformm)
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
                if (CurrentHealth >= 0 && !die) //���� ���� ü���� 0 �ʰ��� ��
                {
                    OnGetDamage?.Invoke(damage, transformm);
                }

                if (CurrentHealth <= 0)
                {
                    if (!die)
                    {
                        die = true;
                        Die(); //�׾��� �� ���Ǵ� �޼��� ȣ��
                    }
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
            _saveX = transform.root.position.x;
            OnDie?.Invoke();
            Debug.Log($"{gameObject} is die");

            StartCoroutine(BgmFadeOut());
        }
    }

    private IEnumerator BgmFadeOut()
    {
        if (_boss)
        {
            yield return new WaitForSeconds(3f);
            SoundManager.Instance.BgmSource.DOFade(0f, 2f);
            InGameManager.Instance.S(_scene);
        }
    }

    private IEnumerator InvincibilityTime()
    {
        _invincibility = true;
        yield return new WaitForSeconds(_invincibilityTime);
        _invincibility = false;
    }
}

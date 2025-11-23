using _00.Work.Lusalord._02.Script.Agent;
using JJM;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSkillManager : Singleton<PlayerSkillManager>
{
    [field: SerializeField] public int SkillNum { get; set; } = 0;

    [SerializeField] private GameObject _slime;
    [SerializeField] private GameObject _spear;

    private int _max;

    private void Start()
    {
        SkillNum = SaveManager.Instance.Data.useItem;

        _max = 0;
        if (SkillNum == 2)
        {
            InGameManager.Instance.Player.GetComponentInChildren<HealthSystem>().MaxHealth += 2;
        }
        if (SkillNum == 4)
        {
            InGameManager.Instance.Player.GetComponentInChildren<AgentMovement>().moveSpeed *= 1.2f;
        }
        if (SkillNum == 5)
        {
            InGameManager.Instance.Player.GetComponentInChildren<MeleeAttackObject>().Damage = 2;
        }
    }


    private void Update()
    {
        if (_max <= 3)
        {
            if (SkillNum == 1)
            {
                if (Mouse.current.rightButton.wasPressedThisFrame)
                {
                    GameObject bullet = Instantiate(_slime);
                    bullet.transform.position = InGameManager.Instance.Player.transform.position;
                    _max++;
                }
            }

            if (SkillNum == 3)
            {
                if (Mouse.current.rightButton.wasPressedThisFrame)
                {
                    GameObject bullet = Instantiate(_spear);
                    bullet.transform.position = InGameManager.Instance.Player.transform.position;
                    _max++;
                }
            }
        }
    }
}

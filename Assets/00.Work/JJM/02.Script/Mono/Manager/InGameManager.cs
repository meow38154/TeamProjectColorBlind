using System;
using Unity.Cinemachine;
using UnityEngine;
using DG.Tweening;

public class InGameManager : Singleton<InGameManager>
{
    [field: SerializeField] public GameObject Player { get; private set; }
    [field: SerializeField] public Boss Boss { get; private set; }
    [field: SerializeField] public CinemachineImpulseSource CinemachineImpulseSource { get; private set; }
    [field: SerializeField] public ManaBar ManaBar { get; private set; }
    [field: SerializeField] public Warning Warning { get; private set; }

    [SerializeField] private Vector3 size;

    public Action OnHealthUpdate;


    public int TargetAndPlayerDirectionValue(Transform targetTransform) //타겟이 플레이어보다 왼쪽에 있는지 오른쪽에 있는 지 판별 후 값을 리턴하는 메서드 
    {
        Vector3 value = targetTransform.position - Player.transform.position; //타겟 위치 - 플레이어 위치 저장

        float valuePosX = value.x; //나온 값에 x만 분리
        float directionValue = value.x / Mathf.Abs(value.x); //(대충 -1이랑 1만 나오게 하는 개 쩌는 공식)

        return Mathf.Clamp(-(int)directionValue, -1, 1); //반환
    }

    public float TargetLook(Transform main, Transform target)
    {
        Vector2 mainPos = main.position;
        Vector2 targetPos = target.position;

        Vector2 dir = targetPos - mainPos;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        return angle;
    }
    public float TargetLook(Vector2 main, Vector2 target)
    {
        Vector2 mainPos = main;
        Vector2 targetPos = target;

        Vector2 dir = targetPos - mainPos;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        return angle;
    }

    public void Afterimage(SpriteRenderer spriteRenderer)
    {
        GameObject image = new GameObject();
        SpriteRenderer r = image.AddComponent<SpriteRenderer>();
        r.flipX = spriteRenderer.flipX;
        image.transform.position = spriteRenderer.transform.position;
        image.transform.rotation = spriteRenderer.transform.rotation;
        image.transform.localScale = size;
        r.sprite = spriteRenderer.sprite;
        Sequence seq = DOTween.Sequence();
        seq.Append(r.DOFade(0, 0.15f));
        seq.AppendCallback(() =>
        {
            Destroy(image);
        });

    }
}

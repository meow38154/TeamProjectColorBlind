using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field: SerializeField] public GameObject Player { get; private set; }

    public int TargetAndPlayerDirectionValue(Transform targetTransform) //타겟이 플레이어보다 왼쪽에 있는지 오른쪽에 있는 지 판별 후 값을 리턴하는 메서드 
    {
        Vector3 value = targetTransform.position - Player.transform.position; //타겟 위치 - 플레이어 위치 저장

        float valuePosX = value.x; //나온 값에 x만 분리
        float directionValue = value.x / Mathf.Abs(value.x); //(대충 -1이랑 1만 나오게 하는 개 쩌는 공식)

        return Mathf.Clamp(-(int)directionValue, -1, 1); //반환
        
    }
}

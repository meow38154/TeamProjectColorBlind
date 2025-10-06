using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Player
{
    public class AgentRenderer : MonoBehaviour
    {
        public void FaceDirection(Vector2 mousePos) // 플레이어의 마우스가 바라보는 방향으로 캐릭터가 바라보도록 설정함
        {
            if (transform.position.x < mousePos.x) // 오른쪽
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (transform.position.x > mousePos.x) // 왼쪽
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
}

using _00.Work.Lusalord._02.Script.Player;
using UnityEngine;

public class AnimationEventBridge : MonoBehaviour
{
    public Player player;

    public void AttackEvent_EnableHitBox()
    {
        player.DamageCaster.attackHandler.EnableHitBox();
    }

    public void AttackEvent_DisableHitBox()
    {
        player.DamageCaster.attackHandler.DisableHitBox();
    }
}

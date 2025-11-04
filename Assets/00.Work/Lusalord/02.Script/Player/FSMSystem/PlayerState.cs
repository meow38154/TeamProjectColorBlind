using _00.Work.Lusalord._02.Script.Agent;
using _00.Work.Lusalord._02.Script.Player;
using _00.Work.Lusalord._02.Script.SO;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    protected Player Player;
    
    protected AnimatorParameterSO StateParam;
    protected bool IsTriggerCall;

    protected AgentRenderer RenderCompo;

    public PlayerState(AnimatorParameterSO param, Player player)
    {
        Player = player;
        StateParam = param;
        RenderCompo = player.GetComponent<AgentRenderer>();
    }

    public virtual void Update()
    {
        
    }

    public virtual void Enter()
    {
        RenderCompo.SetParameter(StateParam, true);
        IsTriggerCall = false;
    }

    public virtual void Exit()
    {
        RenderCompo.SetParameter(StateParam, false);
    }

    public virtual void AnimatorEndTrigger()
    {
        IsTriggerCall = true;
    }
}

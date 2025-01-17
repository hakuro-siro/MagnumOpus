using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public State MoveState;

    protected override void EnterState()
    {
        // Anim 없으니 anim 입장은 다 주석처리 (임시)
        agent.animationManager.PlayAnimation(AnimationType.idle);
    }

    protected override void HandleMovement(Vector3 destination)
    {
        base.HandleMovement(destination);
        agent.TransitionToState(MoveState);
    }

    protected override void HandleQSkill(Vector3 value,AnimationType type)
    {
        base.HandleQSkill(value,type);
        //OnSkill();
    }
    protected override void HandleWSkill(Vector3 value,AnimationType type)
    {
        base.HandleWSkill(value,type);
        //OnSkill();
    }
    protected override void HandleESkill(Vector3 value,AnimationType type)
    {    
        base.HandleESkill(value,type);
        //OnSkill();
    }
    protected override void HandleRSkill(Vector3 value,AnimationType type)
    {
        base.HandleRSkill(value,type);
        //OnSkill();
    }

}

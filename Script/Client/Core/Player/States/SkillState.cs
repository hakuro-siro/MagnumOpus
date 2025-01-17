using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState : State
{
    public State MoveState;
    public State IdleState;

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(agent.CurrentSkillType);
        StartCoroutine(gotoidle());
    }

    IEnumerator gotoidle()
    {
         yield return  new WaitForSeconds(0.5f);
         agent.TransitionToState(IdleState);
    }

    protected override void HandleMovement(Vector3 destination)
    {
        base.HandleMovement(destination);
        agent.TransitionToState(MoveState);
    }



}

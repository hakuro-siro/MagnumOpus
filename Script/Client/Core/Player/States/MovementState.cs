using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class MovementState : State
{
    public State IdleState;
    
    /// <summary>
    /// 이동을 행하는 타겟이 없으면 접근 자체가 불가능한 스테이트
    /// </summary>
    protected override void EnterState()
    {
        // Anim 없으니 anim 입장은 다 주석처리 (임시)
        agent.animationManager.PlayAnimation(AnimationType.run);
        agent.movementData.currentSpeed = 0;
        SetPlayerVelocity();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        CalculateSpeed();
        
        
        // Check if we've reached the destination
        if (!agent.agentNavMesh.pathPending)
        {
            if (agent.agentNavMesh.remainingDistance <= agent.agentNavMesh.stoppingDistance)
            {
                if (!agent.agentNavMesh.hasPath || agent.agentNavMesh.velocity.sqrMagnitude == 0f)
                {  
                    agent.movementData.destination = Vector3.zero;
                    agent.TransitionToState(IdleState);
                }
            }
        }
        
        
    }
    protected override void HandleMovement(Vector3 destination)
    {
        base.HandleMovement(destination);
        SetPlayerVelocity();
    }
    protected void SetPlayerVelocity()
    {
        //Debug.Log($"Destination {agent.movementData.destination}");
        agent.agentNavMesh.destination = agent.movementData.destination;
    }

    protected void CalculateSpeed()
    {
        agent.movementData.currentSpeed = agent.agentData.maxSpeed;
        SetPlayerVelocity();
        agent.agentNavMesh.speed =  agent.movementData.currentSpeed;
    }
    
    protected override void HandleQSkill(Vector3 value,AnimationType type)
    {
        base.HandleQSkill(value,type);
        OnSkill();
    }
    protected override void HandleWSkill(Vector3 value,AnimationType type)
    {
        base.HandleWSkill(value,type);
        OnSkill();
    }
    protected override void HandleESkill(Vector3 value,AnimationType type)
    {    
        base.HandleESkill(value,type);
        OnSkill();
    }
    protected override void HandleRSkill(Vector3 value,AnimationType type)
    {
        base.HandleRSkill(value,type);
        OnSkill();
    }
    private void OnSkill()
    {
        agent.movementData.destination = agent.transform.position;
        SetPlayerVelocity();
        
        agent.networkAgentInput.HandleLocalMovement(agent.transform.position);
    }
    
}

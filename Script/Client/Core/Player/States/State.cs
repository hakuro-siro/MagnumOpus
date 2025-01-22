using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    protected Agent agent;

    public UnityEvent OnEnter, OnExit;
    
    public State SkillState;
    public void InitalizeState(Agent agent)
    {
        this.agent = agent;
    }

    public void Enter()
    {
        this.agent.agentInput.OnMovement += HandleMovement;
        this.agent.agentSkill.OnUseQSkill += HandleQSkill;
        this.agent.agentSkill.OnUseWSkill += HandleWSkill;
        this.agent.agentSkill.OnUseESkill += HandleESkill;
        this.agent.agentSkill.OnUseRSkill += HandleRSkill;
        
        if(agent.agentInput.IsNetwork)
            this.agent.networkAgentInput.OnMovement += HandleMovement;
        OnEnter?.Invoke();
        EnterState();
    }

    protected virtual void EnterState()
    {
    }

    protected virtual void HandleMovement(Vector3 obj)
    {
        //Debug.Log($"input handled pos {obj}");
        agent.movementData.destination = obj;
    }

    protected virtual void HandleQSkill(Vector3 value,AnimationType type)
    {
        agent.CurrentSkillType = type;
        agent.TransitionToState(SkillState);
    }
    protected virtual void HandleWSkill(Vector3 value,AnimationType type)
    {
        agent.CurrentSkillType = type;
        agent.TransitionToState(SkillState);
    }
    protected virtual void HandleESkill(Vector3 value,AnimationType type)
    {
        agent.CurrentSkillType = type;
        agent.TransitionToState(SkillState);
    }
    protected virtual void HandleRSkill(Vector3 value,AnimationType type)
    {
        agent.CurrentSkillType = type;
        agent.TransitionToState(SkillState);
    }
    public virtual void StateUpdate()
    {
        
    }


    public virtual void StateFixedUpdate()
    {

    }
     
    public void Exit()
    {
        this.agent.agentInput.OnMovement -= HandleMovement;
        this.agent.agentSkill.OnUseQSkill -= HandleQSkill;
        this.agent.agentSkill.OnUseWSkill -= HandleWSkill;
        this.agent.agentSkill.OnUseESkill -= HandleESkill;
        this.agent.agentSkill.OnUseRSkill -= HandleRSkill;
        if(agent.agentInput.IsNetwork)
            this.agent.networkAgentInput.OnMovement -= HandleMovement;
        OnExit?.Invoke();
        ExitState();
    }

    protected virtual void ExitState()
    {
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using Script.Client.Core.Player;
using Script.Client.Manager;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Agent : MonoBehaviour
{
    public CharacterID playerid;
    
    /// <summary>
    /// Agent를 3D 환경에 맞게 리팩토링
    /// </summary>
    
    // Agent의 모든 데이터 총괄
    public AgentDataSO agentData;
    
    public Rigidbody rigid;
    public PlayerInput agentInput;
    public PlayerSkills agentSkill;
    public AgentAnimation animationManager;
    public AgentRender agentRender;
    public NavMeshAgent agentNavMesh;
    public MovementData movementData;
    public State currentState = null, previousState = null;
    public State IdleState;
    public AnimationType CurrentSkillType;
    public NetworkAgentInput networkAgentInput;
    public NetworkObjectData networkobjData;
    public AgentCanvas canvas;
    public Transform SKillCharger;
    [Header("State  Debugging")]
    public string stateName= "";
    
    [field: SerializeField]
    private  UnityEvent OnRespawnRequired { get; set; }

    private void Awake()
    {
        // Agent 의 모든 인자를 초기화
        agentInput = GetComponentInParent<PlayerInput>();
        rigid = GetComponent<Rigidbody>();
        animationManager = GetComponentInChildren<AgentAnimation>();
        agentRender = GetComponentInChildren<AgentRender>();
        agentNavMesh = GetComponent<NavMeshAgent>();
        movementData = GetComponent<MovementData>();
        networkAgentInput = GetComponent<NetworkAgentInput>();
        agentSkill = GetComponentInChildren<PlayerSkills>();
        networkobjData = GetComponentInParent<NetworkObjectData>();
       // canvas = GetComponentInChildren<AgentCanvas>();
        State[] states = GetComponentsInChildren<State>();
        
        foreach(var state in states)
        {
            state.InitalizeState(this);
        }
        if(agentInput.IsNetwork)
            networkAgentInput.InitalizeNetworkAgent(this);
    }

    private void Start()
    {
        TransitionToState(IdleState);
    }


    internal void TransitionToState(State desiredState)
    {
        if (desiredState == null)
            return;
        if(currentState != null)
        {
            currentState.Exit();
        }

        previousState = currentState;
        currentState = desiredState;
        currentState.Enter();

        displayState();
    }

    private void displayState()
    {
        if (previousState == null || previousState.GetType() != currentState.GetType())
        {
            stateName = currentState.GetType().ToString();
        }
    }


    private void Update()
    {
        
        currentState.StateUpdate();
    }
    private void FixedUpdate()
    {
        currentState.StateFixedUpdate();
    }

    public void AgentDied()
    {
        OnRespawnRequired?.Invoke();
    }
}


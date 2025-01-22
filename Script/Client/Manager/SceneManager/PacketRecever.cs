using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Google.Protobuf.Protocol;

public class PacketRecever : MonoBehaviour
{
    // public PacketHandler handler;
    public IObservable<S_EnterGame> OnEnterGame => _EnterGame; private readonly ReactiveProperty<S_EnterGame> _EnterGame = new();
    public IObservable<S_Move> OnPlayerMove => _PlayerMove; private readonly ReactiveProperty<S_Move> _PlayerMove = new();
    public IObservable<S_Connect> OnConnect => _Connect; private readonly ReactiveProperty<S_Connect> _Connect = new();
    public IObservable<S_Spawn> OnSpawn => _Spawn; private readonly ReactiveProperty<S_Spawn> _Spawn = new();
    public IObservable<S_StartGame> OnStartGame => _StartGame; private readonly ReactiveProperty<S_StartGame> _StartGame = new();
    public IObservable<S_SceneLoadEnd> OnAllLoaded => _AllLoaded; private readonly ReactiveProperty<S_SceneLoadEnd> _AllLoaded = new();
    public IObservable<S_Skill> OnSkillUse => _SkillUse; private readonly ReactiveProperty<S_Skill> _SkillUse = new();
    public IObservable<S_Hit> OnHit => _Hit; private readonly ReactiveProperty<S_Hit> _Hit = new();
    public IObservable<S_SkillAnimation> OnSkillAnim => _Anim; private readonly ReactiveProperty<S_SkillAnimation> _Anim = new();
    public IObservable<S_Win> OnWin => _Win; private readonly ReactiveProperty<S_Win> _Win = new();

    
    private void Awake()
    {
        _Connect.Value = new S_Connect();
        _Spawn.Value = new S_Spawn();
        _EnterGame.Value = new S_EnterGame();
        _PlayerMove.Value = new S_Move();
        _StartGame.Value = new S_StartGame();
        _AllLoaded.Value = new S_SceneLoadEnd();
        _SkillUse.Value = new S_Skill();
        _Hit.Value = new S_Hit();
        _Anim.Value =new S_SkillAnimation();
        _Win.Value =new S_Win();

    }

    public void ClearRecever()
    {
        //_Connect.Value = new S_Connect();
        _Spawn.Value = new S_Spawn();
        _EnterGame.Value = new S_EnterGame();
        _PlayerMove.Value = new S_Move();
        _StartGame.Value = new S_StartGame();
        _AllLoaded.Value = new S_SceneLoadEnd();
        _SkillUse.Value = new S_Skill();
        _Hit.Value = new S_Hit();
        _Anim.Value =new S_SkillAnimation();
        _Win.Value =new S_Win();
    }
    public void SubscribePacketHandler()
    {
        PacketHandler.IsPacketRecved.AsObservable().Subscribe(_ => OnPacketReceved(_));
    }
    public void OnPacketReceved(object argument)
    {
        OnPacketRecevedHandlder(argument);
    }
    protected void OnPacketRecevedHandlder(object argument)
    {

        if (argument as S_Move != null)
        {
            S_Move pkt = argument as S_Move;
            _PlayerMove.Value = pkt;
        }
        if (argument as S_EnterGame != null)
        {
            //entergame
            S_EnterGame pkt = argument as S_EnterGame;
            _EnterGame.Value = pkt;
        }
        if (argument as S_Connect != null)
        {
            //connect
            S_Connect pkt = argument as S_Connect;
            _Connect.Value = pkt;
        }
        if (argument as S_Spawn != null)
        {
            //spawn
            S_Spawn pkt = argument as S_Spawn;
            _Spawn.Value = pkt;
        }
        if (argument as S_StartGame != null)
        {
            //InGame Start
            S_StartGame pkt = argument as S_StartGame;
            _StartGame.Value = pkt;
        }        
        if (argument as S_SceneLoadEnd != null)
        {
            //all loaded
            S_SceneLoadEnd pkt = argument as S_SceneLoadEnd;
            _AllLoaded.Value = pkt;
        }        
        if (argument as S_Skill != null)
        {
            //all loaded
            S_Skill pkt = argument as S_Skill;
            _SkillUse.Value = pkt;
        }
        
        if (argument as S_Hit != null)
        {
            
            //all loaded
            Debug.Log("on hit!!");
            S_Hit pkt = argument as S_Hit;
            if(pkt.Damage==0)
                return;
            _Hit.Value = new S_Hit();
            _Hit.Value = pkt;
        }
        if (argument as S_SkillAnimation != null)
        {
            //all loaded
            Debug.LogWarning("Non Invoke Animation");
            _Anim.Value = new S_SkillAnimation();
            S_SkillAnimation pkt = argument as S_SkillAnimation;
            _Anim.Value = pkt;
        }
        if (argument as S_Win != null)
        {
            //all loaded
            S_Win pkt = argument as S_Win;
            _Win.Value = pkt;
        }
    }

}

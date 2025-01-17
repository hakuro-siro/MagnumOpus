using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core;
using Script.Client.Manager;
using UniRx;
using UnityEngine;
using Google.Protobuf;
using Google.Protobuf.Protocol;
using Script.Client.Manager.SceneManager;

public static class PacketHandler
{
    public static IObservable<IMessage> IsPacketRecved => _PacketRecved;
    private static readonly ReactiveProperty<IMessage> _PacketRecved = new();

    public static void S_MoveAction(PacketSession session, IMessage packet)
    {
        S_Move movepkt = packet as S_Move;
        //movepkt.positionInfo;
//        Debug.Log("--RECV PACKET--");
        _PacketRecved.Value = packet;
    }

    public static void S_HitAction(PacketSession session, IMessage packet)
    {
        S_Hit pkt = packet as S_Hit;
        //movepkt.positionInfo;
        
        Debug.Log($"Damaged ");//: {pkt.ObjInfo} Value IS : {pkt.Damage}");
        
        _PacketRecved.Value = new S_Hit();
        _PacketRecved.Value = packet;
        
        
    }
    
    
//S_SkillAnimationAction
    public static void S_SkillAnimationAction(PacketSession session, IMessage packet)
    {
        _PacketRecved.Value = packet;
        
        
        
        
    }
    //S_WinAction
    public static void S_WinAction(PacketSession session, IMessage packet)
    {
        _PacketRecved.Value = packet;
    }
    
    //S_EnterGameAction
    public static void S_EnterGameAction(PacketSession session, IMessage packet)
    {
        Debug.Log("--EnterGame--");
        S_EnterGame pkt = packet as S_EnterGame;
        _PacketRecved.Value = packet;
        
    }

    //S_LeaveGameAction
    public static void S_LeaveGameAction(PacketSession session, IMessage packet)
    {

    }
//S_MatchingLeaveAction
    public static void S_MatchingLeaveAction(PacketSession session, IMessage packet)
    {

    } 
    //S_SpawnAction
    public static void S_SpawnAction(PacketSession session, IMessage packet)
    {
        S_Spawn pkt = packet as S_Spawn;
        _PacketRecved.Value = packet;
        Debug.Log($"S_Spawn Pkt : {pkt.ObjInfos}");


    }
    
    public static void S_SceneLoadEndAction(PacketSession session, IMessage packet)
    {
        Debug.Log("--SceneLoaded Hadled--");
        S_SceneLoadEnd pkt = packet as S_SceneLoadEnd;
        _PacketRecved.Value = packet;
    }

    
    //S_DespawnAction
    public static void S_DespawnAction(PacketSession session, IMessage packet)
    {
        S_Despawn pkt = packet as S_Despawn;
        InGameSceneManager.instance.DeleteObject(pkt);
    }
    

    //S_ConnectAction
    //If Connected
    public static void S_ConnectAction(PacketSession session, IMessage packet)
    {
        S_Connect pkt = packet as S_Connect;
        // pkt.id
        _PacketRecved.Value = packet;
    }

    //S_MatchingAction
    public static void S_MatchingAction(PacketSession session, IMessage packet)
    {

    }

    //S_StartGameAction
    public static void S_StartGameAction(PacketSession session, IMessage packet)
    {
        S_StartGame pkt = packet as S_StartGame;
        _PacketRecved.Value = packet;
        Debug.Log($"S_Startgame : {pkt.ObjInfo.PosInfo}");
    }

    public static void S_SkillAction(PacketSession session, IMessage packet)
    {
        S_Skill pkt = packet as S_Skill;
        _PacketRecved.Value = packet;
    }

    public static void S_ChangeHpAction(PacketSession session, IMessage packet)
    {
        
    }

    public static void S_DieAction(PacketSession session, IMessage packet)
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Script.Client.Manager;
using UnityEngine;
using UniRx;
using Google.Protobuf.Protocol;

public class NetworkAgentInput : MonoBehaviour
{
    /// <summary>
    /// Agent와 네트워크의 통신 handler
    /// </summary>
    [SerializeField]
    protected Agent agent;
    // need Value Event System
    
    public event Action<Vector3> OnMovement;
    public void InitalizeNetworkAgent(Agent agent)
    {
        this.agent = agent;
        this.agent.agentInput.OnMovement += HandleLocalMovement;
    }
    
    private void Awake()
    {
    }

    [SerializeField]
    private PacketRecever rec;

    public IDisposable dis1;
    public IDisposable dis2;
    public void SubscribePacketRecever(PacketRecever recever)
    {
        rec = recever;
        Debug.Log($"subscribe move packet p id {agent.networkobjData.Objid}");
        dis1 = recever.OnPlayerMove.Subscribe(value => GetNetworkMovementInput(value));
        dis2 = recever.OnSkillAnim.Subscribe(value => UseSkillAnimation(value));
    }

    public void UseSkillAnimation(S_SkillAnimation anim)
    {
        if(anim==null)
            return;
        
        if(anim.ObjectId == 0)
            return;

        Debug.Log($"" +
                  $"object id {anim.ObjectId} " +
                  $"player id {MagicaClientMain.instance.playerDataManager.GetPlayerId()}");

        //Debug.lo
        if (anim.ObjectId == MagicaClientMain.instance.playerDataManager.GetPlayerId())
        {
            Debug.Log("Animation Skip!");
            return;
        }
        if (agent.networkobjData.Objid == MagicaClientMain.instance.playerDataManager.GetPlayerId())
        {
            Debug.Log("Animation Skip!");
            return;
        }
        
        Debug.Log("Animation Play!");
        
        switch ((Skills)anim.SkillId)
        {
            case Skills.RapidFire:
                agent.animationManager.PlayAnimation(AnimationType.RapidFireInvokeLess);
                break;
            case Skills.Empattack:
                agent.animationManager.PlayAnimation(AnimationType.EMPAttackInvokeLess);
                break;
            case Skills.SateliteBeam:
                agent.animationManager.PlayAnimation(AnimationType.SateliteBeamInvokeLess);
                break;
            case Skills.MultipleShot:
                agent.animationManager.PlayAnimation(AnimationType.MultipleShotInvokeLess);
                break;
            case Skills.BigShot:
                agent.animationManager.PlayAnimation(AnimationType.BigShotInvokeLess);
                break;
            case Skills.BrandishingGunFire:
                agent.animationManager.PlayAnimation(AnimationType.BrandishingGunFireInvokeLess);
                break;
            case Skills.CoreBeam:
                agent.animationManager.PlayAnimation(AnimationType.CoreBeamInvokeLess);
                break;
            case Skills.GroundScatter:
                agent.animationManager.PlayAnimation(AnimationType.GroundScatterInvokeLess);
                break;
            case Skills.IceFatalWheel:
                agent.animationManager.PlayAnimation(AnimationType.IceFatalWheelInvokeLess);
                break;
            case Skills.LumenJudgement:
                agent.animationManager.PlayAnimation(AnimationType.LumenJudgementInvokeLess);
                break;
            case Skills.FloatingWindStorm:
                agent.animationManager.PlayAnimation(AnimationType.FloatingWindStormInvokeLess);
                break;
            case Skills.LightingStrike:
                agent.animationManager.PlayAnimation(AnimationType.LightingStrike);
                break;
            case Skills.IceRing:
                agent.animationManager.PlayAnimation(AnimationType.IceRingInvokeLess);
                break;
            case Skills.SprialWheels:
                agent.animationManager.PlayAnimation(AnimationType.SprialWheelsInvokeLess);
                break;
        }
        
    }
    
    
    private Vector3 LocalDesPosition;
    private Vector3 NetworkDesPosition;
    
    
    // Local Handle 에 인한 변화 (이 메소드의 호출은 최종 목적지의 변경을 의미함)
    public void HandleLocalMovement(Vector3 Changedlocalpos)
    {
        SendLocalMovement(GenerateMovePacket(Changedlocalpos));
    }
    private C_Move GenerateMovePacket(Vector3 pos)
    {
        C_Move pkt = new C_Move();
        pkt.ObjectId = MagicaClientMain.instance.playerDataManager.GetPlayerId();
        pkt.Speed = 1;
        PositionInfo posinfo = new PositionInfo();
        Vector3 point = new Vector3(
            (float)Math.Truncate(pos.x * 10) / 10, 
            (float)Math.Truncate(pos.z * 10) / 10,
            (float)Math.Truncate(pos.y * 10) / 10);
        posinfo.PosX = point.x;
        posinfo.PosY = point.y;
        LocalDesPosition = point;
        pkt.PosInfo = posinfo;
        return pkt;
    }

    private void SendLocalMovement(C_Move pkt)
    {
       /// Debug.Log("Sent Move Packet!");
        NetworkManager.Instance.Send(pkt);
    }
    public void SendUseSkill(C_Skill pkt)
    {
        Debug.Log("Sent Skill Packet!");
        NetworkManager.Instance.Send(pkt);
    }

    public void SendSkillanim(C_SkillAnimation pkt)
    {
        NetworkManager.Instance.Send(pkt);
    }
    /// <summary>
    /// Recv
    /// </summary>
    /// <param name="posinfo"></param>
    public void GetNetworkMovementInput(S_Move info)
    {
        //Debug.Log($"Handled network obj data {agent.networkobjData.Objid}");

        if (info.ObjectId != agent.networkobjData.Objid)
        {
            //Debug.Log($"object id {info.ObjectId} network obj data {agent.networkobjData.Objid}");
            //Debug.Log("Input Refused BY OBJID");
            return;
        }

        if (info.ObjectId == MagicaClientMain.instance.playerDataManager.GetControllObject())
        { 
            //Debug.Log("Input Refused BY GetControllObject");
            return;
        }

        //Debug.Log("Recv Move Packet!");
        if (agent == null)
            agent = GetComponent<Agent>();
        Vector3 pos = new Vector3(info.PosInfo.PosX, agent.transform.position.y, info.PosInfo.PosY);
        NetworkDesPosition = pos;
        //Debug.Log($"pos value : {pos}");
        OnMovement?.Invoke(pos);
    }

    private void OnDestroy()
    {
        dis1.Dispose();
        dis2.Dispose();
    }
}

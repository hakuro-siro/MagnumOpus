using System;
using System.Collections;
using System.Collections.Generic;
using Google.Protobuf.Protocol;
using Script.Client.Manager;
using Script.Client.View;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


//원형
public class NoMovingSkill : Skill
{
    private Vector3 newHitpos;
    
    protected override void IStart()
    {
        TargetCircle.GetComponent<Image>().enabled = false;
        IndicatorRangeCircle.GetComponent<Image>().enabled = false;
    }

    protected override void IUpdate()
    {
        if (CanUseSkill)
            SkillClickCheck();
        else
        {
            //if cannot Release Skill...
            IndicatorRangeCircle.GetComponent<Image>().enabled = false;
            TargetCircle.GetComponent<Image>().enabled = false;
        }
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject != this.gameObject)
            {
                PosUp = new Vector3(hit.point.x, 10f, hit.point.z);
                position = hit.point;
            }
        }

        var hitposDir = (hit.point - transform.position).normalized;
        float distance = Vector3.Distance(hit.point, transform.position);
        distance = Mathf.Min(distance, maxAbility2Distance);

        

        switch (skillid)
        {
            case Skills.SateliteBeam:
                newHitpos = transform.position+ hitposDir * distance;
                break;
            case Skills.LumenJudgement:
                newHitpos = transform.position+ hitposDir * distance;
                break;
            case Skills.LightingStrike:
                newHitpos = transform.position+ hitposDir * distance;
                break;
            default:
                newHitpos = transform.position; //+ hitposDir * distance;
                break;
        }

        SkillCanvas.transform.position = (newHitpos);

    }
    private void SkillClickCheck()
    {
        if (Input.GetKey(SkillKeycode) && isCooldown == false)
        {
            skillmanager.DisableSkillsWithoutThis(this);
            TargetCircle.GetComponent<Image>().enabled = true;
            IndicatorRangeCircle.GetComponent<Image>().enabled = true;
        }
        else
        {
            TargetCircle.GetComponent<Image>().enabled = false;
            IndicatorRangeCircle.GetComponent<Image>().enabled = false;
            skillmanager.EnableAllSkill();
        }
        //애니메이션 장전!
        if (TargetCircle.GetComponent<Image>().enabled == true && Input.GetMouseButton(0))
        {
            //여기서 애니메이션 패킷
            isCooldown = true;
            Vector3 skillDes = new Vector3(newHitpos.x, 1, newHitpos.z);
            
            C_SkillAnimation pkt  = new C_SkillAnimation();
            PlayerDataManager playerdata = FindObjectOfType<PlayerDataManager>();
            pkt.ObjectId = playerdata.GetPlayerId();
            
            Debug.Log( pkt.ObjectId);
        Debug.Log(skillid);
       switch (skillid)    
        {
            case Skills.Empattack:
                AnimationInVoker.instance.OnAnimEmpAttack += UseSkill;
                pkt.SkillId = (int)Skills.Empattack;
                break;
            case Skills.BigShot:
                AnimationInVoker.instance.OnAnimBigShot +=UseSkill;
                pkt.SkillId = (int)Skills.BigShot;
                break;
            case Skills.CoreBeam:
                AnimationInVoker.instance.OnAnimCoreBeam += UseSkill;
                pkt.SkillId = (int)Skills.CoreBeam;
                break;
            case Skills.GroundScatter:
                AnimationInVoker.instance.OnAnimGroundScatter +=UseSkill;
                pkt.SkillId = (int)Skills.GroundScatter;
                break;
            case Skills.IceRing:
                AnimationInVoker.instance.OnAnimIceRing +=UseSkill;
                pkt.SkillId = (int)Skills.IceRing;
                break;
            case Skills.LightingStrike:
                AnimationInVoker.instance.OnAnimLightingStrike += UseSkill;
                pkt.SkillId = (int)Skills.LightingStrike;
                break;
            case Skills.LumenJudgement:
                AnimationInVoker.instance.OnAnimLumenJudgement +=UseSkill;
                pkt.SkillId = (int)Skills.LumenJudgement;
                break;
            case Skills.MultipleShot:
                AnimationInVoker.instance.OnAnimMultipleShot +=UseSkill;
                pkt.SkillId = (int)Skills.MultipleShot;
                break;
            case Skills.RapidFire:
                AnimationInVoker.instance.OnAnimRapidFire +=UseSkill;
                pkt.SkillId = (int)Skills.RapidFire;
                break;
            case Skills.SateliteBeam:
                AnimationInVoker.instance.OnAnimSateliteBeam += UseSkill;
                pkt.SkillId = (int)Skills.SateliteBeam;
                break;
            case Skills.SprialWheels:
                AnimationInVoker.instance.OnAnimSprialWheels += UseSkill;
                pkt.SkillId = (int)Skills.SprialWheels;
                break;
            case Skills.BrandishingGunFire:
                AnimationInVoker.instance.OnAnimBrandishingGunFire +=UseSkill;
                pkt.SkillId = (int)Skills.BrandishingGunFire;
                break;
            case Skills.FloatingWindStorm:
                AnimationInVoker.instance.OnAnimFloatingWindStorm +=UseSkill;
                pkt.SkillId = (int)Skills.FloatingWindStorm;
                break;
            case Skills.IceFatalWheel:
                AnimationInVoker.instance.OnAnimIceFatalWheel +=UseSkill;
                pkt.SkillId = (int)Skills.IceFatalWheel;
                break;
        }
       skillmanager.agent.networkAgentInput.SendSkillanim(pkt);

        EnvokeSkillUse(skillDes,animtype);
        switch (skillid)    
        {
            case Skills.Empattack:
                StartCoroutine(CoolTimer(3f));
                break;
            case Skills.BigShot:
                StartCoroutine(CoolTimer(2f));
                break;
            case Skills.CoreBeam:
                StartCoroutine(CoolTimer(3f));
                break;
            case Skills.GroundScatter:
                StartCoroutine(CoolTimer(3f));
                break;
            case Skills.IceRing:
                StartCoroutine(CoolTimer(999f));
                break;
            case Skills.LightingStrike:
                StartCoroutine(CoolTimer(5f));
                break;
            case Skills.LumenJudgement:
                StartCoroutine(CoolTimer(5f));
                break;
            case Skills.MultipleShot:
                StartCoroutine(CoolTimer(2f));
                break;
            case Skills.RapidFire:
                StartCoroutine(CoolTimer(2f));
                break;
            case Skills.SateliteBeam:
                StartCoroutine(CoolTimer(4f));
                break;
            case Skills.SprialWheels:
                StartCoroutine(CoolTimer(999f));
                break;
            case Skills.BrandishingGunFire:
                StartCoroutine(CoolTimer(5f));
                break;
            case Skills.FloatingWindStorm:
                StartCoroutine(CoolTimer(3f));
                break;
            case Skills.IceFatalWheel:
                StartCoroutine(CoolTimer(999f));
                break;
        }  
        
        }       
        if (isCooldown)
        {
            IndicatorRangeCircle.GetComponent<Image>().enabled = false;
            TargetCircle.GetComponent<Image>().enabled = false;
        }
    }
    IEnumerator CoolTimer(float time)
    {
        int timer =0;
        while (true)
        {
            yield return new WaitForSeconds(1f);
            timer++;

            switch (SkillKeycode)
            {
                case KeyCode.Q:
                    InGameSceneView.instance.UpdateQCoolTime((time - timer).ToString());
                    break;
                case KeyCode.W:
                    InGameSceneView.instance.UpdateWCoolTime((time - timer).ToString());
                    break;
                case KeyCode.E:
                    InGameSceneView.instance.UpdateECoolTime((time - timer).ToString());
                    break;
                case KeyCode.R:
                    InGameSceneView.instance.UpdateRCoolTime((time - timer).ToString());
                    break;
            }
            
            if (timer >= time)
            {
                isCooldown = false;
                switch (SkillKeycode)
                {
                    case KeyCode.Q:
                        InGameSceneView.instance.ClearQCoolTime();
                        break;
                    case KeyCode.W:
                        InGameSceneView.instance.ClearWCoolTime();
                        break;
                    case KeyCode.E:
                        InGameSceneView.instance.ClearECoolTime();
                        break;
                    case KeyCode.R:
                        InGameSceneView.instance.ClearRCoolTime();
                        break;
                }
                break;
            }
            yield return null;
        }
        
    }
    // 오브젝트를 소환!
    private void UseSkill()
    {
        C_Skill pkt = new C_Skill();
        PositionInfo info = new PositionInfo();
        Debug.Log("Catch!");
         switch (skillid)    
        {
            case Skills.Empattack:
                AnimationInVoker.instance.OnAnimEmpAttack -= UseSkill;
                pkt.SkillId = (int)Skills.Empattack;
                break;
            case Skills.BigShot:
                AnimationInVoker.instance.OnAnimBigShot -= UseSkill;
                pkt.SkillId = (int)Skills.BigShot;
                break;
            case Skills.CoreBeam:
                AnimationInVoker.instance.OnAnimCoreBeam -= UseSkill;
                pkt.SkillId = (int)Skills.CoreBeam;
                break;
            case Skills.GroundScatter:
                AnimationInVoker.instance.OnAnimGroundScatter -= UseSkill;
                pkt.SkillId = (int)Skills.GroundScatter;
                break;
            case Skills.IceRing:
                AnimationInVoker.instance.OnAnimIceRing -= UseSkill;
                pkt.SkillId = (int)Skills.IceRing;
                break;
            case Skills.LightingStrike:
                AnimationInVoker.instance.OnAnimLightingStrike -= UseSkill;
                pkt.SkillId = (int)Skills.LightingStrike;
                break;
            case Skills.LumenJudgement:
                AnimationInVoker.instance.OnAnimLumenJudgement -= UseSkill;
                pkt.SkillId = (int)Skills.LumenJudgement;
                break;
            case Skills.MultipleShot:
                AnimationInVoker.instance.OnAnimMultipleShot -= UseSkill;
                pkt.SkillId = (int)Skills.MultipleShot;
                break;
            case Skills.RapidFire:
                AnimationInVoker.instance.OnAnimRapidFire -= UseSkill;
                pkt.SkillId = (int)Skills.RapidFire;
                break;
            case Skills.SateliteBeam:
                AnimationInVoker.instance.OnAnimSateliteBeam -= UseSkill;
                pkt.SkillId = (int)Skills.SateliteBeam;
                break;
            case Skills.SprialWheels:
                AnimationInVoker.instance.OnAnimSprialWheels -= UseSkill;
                pkt.SkillId = (int)Skills.SprialWheels;
                break;
            case Skills.BrandishingGunFire:
                AnimationInVoker.instance.OnAnimBrandishingGunFire -= UseSkill;
                pkt.SkillId = (int)Skills.BrandishingGunFire;
                break;
            case Skills.FloatingWindStorm:
                AnimationInVoker.instance.OnAnimFloatingWindStorm -= UseSkill;
                pkt.SkillId = (int)Skills.FloatingWindStorm;
                break;
            case Skills.IceFatalWheel:
                AnimationInVoker.instance.OnAnimIceFatalWheel -= UseSkill;
                pkt.SkillId = (int)Skills.IceFatalWheel;
                break;
        }

            
        Vector3 point = new Vector3(
            (float)Math.Truncate(newHitpos.x * 10) / 10, 
            (float)Math.Truncate(newHitpos.z * 10) / 10,
            (float)Math.Truncate(newHitpos.y * 10) / 10);
        info.PosX = point.x;
        info.PosY = point.y;
            
        pkt.TargetPos = info;
        pkt.ObjectId = MagicaClientMain.instance.playerDataManager.GetPlayerId();
            //pkt.SkillId = (int)Skills.Empattack;
        Debug.Log($"skill pos : {newHitpos}");
        skillmanager.agent.networkAgentInput.SendUseSkill(pkt);
    }
    
}

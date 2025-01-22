using System;
using System.Collections;
using System.Collections.Generic;
using Google.Protobuf.Protocol;
using Script.Client.Manager;
using UnityEngine;
using UnityEngine.UI;

//직선형
public class RapidFire : Skill
{  
    
    protected override void IStart()
    {
        SkillShot.GetComponent<Image>().enabled = false;
    }

    protected override void IUpdate()
    {
        if (CanUseSkill)
            SkillClickCheck();
        else
        {
            //if cannot Release Skill...
            SkillShot.GetComponent<Image>().enabled = false;
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }

        Quaternion transRot = Quaternion.LookRotation(position - player.transform.position);
        transRot.eulerAngles = new Vector3(90, transRot.eulerAngles.y, transRot.eulerAngles.z);
        SkillCanvas.transform.rotation = Quaternion.Lerp(transRot, SkillCanvas.transform.rotation, 0f);
    }

    private void SkillClickCheck()
    {
        if (Input.GetKey(SkillKeycode) && isCooldown == false)
        {
            //Debug.Log("release skill demo 1");
            SkillShot.GetComponent<Image>().enabled = true;
            skillmanager.DisableSkillsWithoutThis(this);
        }
        else
        {
            SkillShot.GetComponent<Image>().enabled = false;
            skillmanager.EnableAllSkill();
        }
    ///애니메이션 장전!
        if (SkillShot.GetComponent<Image>().enabled == true && Input.GetMouseButton(0))
        {
            isCooldown = true;
            Vector3 skillDes = new Vector3(SkillPos.position.x, 1, SkillPos.position.z);
            
            C_SkillAnimation pkt  = new C_SkillAnimation();
            PlayerDataManager playerdata = FindObjectOfType<PlayerDataManager>();
            pkt.ObjectId = playerdata.GetPlayerId();
            pkt.SkillId = (int)Skills.RapidFire;
            skillmanager.agent.networkAgentInput.SendSkillanim(pkt);
            AnimationInVoker.instance.OnAnimRapidFire += UseSkill;
            
            EnvokeSkillUse(skillDes,animtype);
            //UseSkill(skillDes);
            StartCoroutine(CoolTimer(0.5f));
        }

        if (isCooldown)
        {
            SkillShot.GetComponent<Image>().enabled = false;
        }
    }

    IEnumerator CoolTimer(float time)
    {
        while (true)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                isCooldown = false;
                break;
            }

            yield return null;
        }
        
    }
    //오브젝트 생성!
    private void UseSkill()
    {
        AnimationInVoker.instance.OnAnimRapidFire -= UseSkill;
        //Debug.Log("Use Skill demo 1");
        C_Skill pkt = new C_Skill();
        PositionInfo info = new PositionInfo();
            
        Vector3 point = new Vector3(
            (float)Math.Truncate(SkillPos.position.x * 10) / 10, 
            (float)Math.Truncate(SkillPos.position.z * 10) / 10,
            (float)Math.Truncate(SkillPos.position.y * 10) / 10);
        info.PosX = point.x;
        info.PosY = point.y;
            
        pkt.TargetPos = info;
        pkt.ObjectId = MagicaClientMain.instance.playerDataManager.GetPlayerId();
        pkt.SkillId = (int)Skills.RapidFire;
        //Debug.Log($"skill pos : {SkillPos.position}");
        skillmanager.agent.networkAgentInput.SendUseSkill(pkt);

    }
}

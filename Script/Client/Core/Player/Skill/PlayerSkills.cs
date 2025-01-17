using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PlayerSkills : MonoBehaviour
{
    public Agent agent;
    
    public List<Skill> agentSkills;
    public Skill Qskill;
    public Skill Wskill;
    public Skill Eskill;
    public Skill Rskill;
    
    public event Action<Vector3,AnimationType> OnUseQSkill;
    public event Action<Vector3,AnimationType> OnUseWSkill;
    public event Action<Vector3,AnimationType> OnUseESkill;
    public event Action<Vector3,AnimationType> OnUseRSkill;
    
    //Wskill.OnSkillUse += onuseWskill;
    //Eskill.OnSkillUse += onuseEskill;
    //Rskill.OnSkillUse += onuseRskill;
    public void InitQSkills(Skill skill)
    {
        agentSkills.Add(skill);
        Qskill = skill;
        skill.skillmanager = this;
        skill.player = agent.transform;
        skill.SkillKeycode = KeyCode.Q;
        Qskill.OnSkillUse += onuseQskill;
    }
    public void InitWSkills(Skill skill)
    { 
        agentSkills.Add(skill);
        Wskill = skill;
        skill.player = agent.transform;
        skill.skillmanager = this;
        
        skill.SkillKeycode = KeyCode.W;
        Wskill.OnSkillUse += onuseWskill;
    }    
    public void InitESkills(Skill skill)
    { 
        agentSkills.Add(skill);
        Eskill = skill;
        skill.player = agent.transform;
        
        skill.SkillKeycode = KeyCode.E;
        skill.skillmanager = this;
        Eskill.OnSkillUse += onuseEskill;
    }    
    public void InitRSkills(Skill skill)
    { 
        agentSkills.Add(skill);
        Rskill = skill;
        skill.player = agent.transform;
        
        skill.SkillKeycode = KeyCode.R;
        skill.skillmanager = this;
        Rskill.OnSkillUse += onuseRskill;
    }
    
    
    private void onuseQskill(Vector3 value,AnimationType type)
    {
        OnUseQSkill?.Invoke(value,type);
    }
    private void onuseWskill(Vector3 value,AnimationType type)
    {
        OnUseWSkill?.Invoke(value,type);
    }
    private void onuseEskill(Vector3 value,AnimationType type)
    {
        OnUseESkill?.Invoke(value,type);
    }
    private void onuseRskill(Vector3 value,AnimationType type)
    {
        OnUseRSkill?.Invoke(value,type);
    }
    public void DisableSkillsWithoutThis(Skill skill)
    {
        foreach (var item in agentSkills)
        {
            if(item!=skill)
                item.DisableMySkill();
        }
    }
    
    public void EnableAllSkill()
    {
        foreach (var item in agentSkills)
        {
            item.EnableMySkill();
        }
    }
}

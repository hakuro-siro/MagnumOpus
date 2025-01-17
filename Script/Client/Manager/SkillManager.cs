using System;
using System.Collections.Generic;
using Google.Protobuf.Protocol;
using UnityEngine;

namespace Script.Client.Manager
{
    public class SkillManager : MonoBehaviour
    {
        public List<GameObject> ChargedSkills;
        public List<GameObject> SkillObjList;

        private CharacterDataManager CharacterDataManager;
        
        internal void GetCharacterDataManager(CharacterDataManager value)
        {
            CharacterDataManager = value;
        }

        private void Awake()
        {
            ChargeSkill("RapidFire");
            ChargeSkill("Empattack");
            ChargeSkill("SateliteBeam");
            ChargeSkill("MultipleShot");
            ChargeSkill("BigShot");
            ChargeSkill("BrandishingGunFire");
            ChargeSkill("CoreBeam");
            ChargeSkill("GroundScatter");
            ChargeSkill("IceRing");
            ChargeSkill("IceFatalWheel");
            ChargeSkill("LumenJudgement");
            ChargeSkill("FloatingWindStorm");
            ChargeSkill("LightingStrike");
            ChargeSkill("SprialWheels");
            
        }



        public GameObject GetChargedSkill(Skills id)
        {
            foreach (var skill in ChargedSkills)
            {
                if (skill.GetComponent<Skill>().skillid == id)
                {
                    Debug.Log("found skill");
                    return skill;
                }    
            }

            return null;
        }
        public GameObject GetChargedSkillOBJ(Skills id)
        {
            foreach (var skill in SkillObjList)
            {
                if (skill.GetComponent<SkillObj>().skillid == id)
                {
                    Debug.Log("found skillobj");
                    return skill;
                }    
            }

            return null;
        }
        public void ChargeSkill(string skillid)
        {
            //string 으로 받은 id로 enum 대조
            Skills skillpath = (Skills)Enum.Parse(typeof(Skills), skillid);
            GameObject skill = LoadSkillByID(skillpath);
            ChargedSkills.Add(skill);
            SkillObjList.Add(skill.GetComponent<Skill>().SkillObject);
        }
        public static string SkillPath = "Container/";
        public GameObject LoadSkillByID(Skills id)
        {
            Debug.Log(SkillPath+id.ToString());
            GameObject skillobj = Resources.Load<GameObject>(SkillPath+id.ToString());
            return skillobj;
        }
    }

    /*
    public enum SkillID
    {
        DemoSkill1,
        DemoSkill2
    }
    
    public enum SupSkillID
    {
        SubSkill1,
        SubSkill2
    }
    */
    
}
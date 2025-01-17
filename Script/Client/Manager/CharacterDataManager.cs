using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Script.Client.Manager
{
    // 캐릭터 정보 가져오기 : 여기서 캐릭터 액세스 가능함
    public class CharacterDataManager : MonoBehaviour
    {
        //캐릭터 리스트
        //여기 리스트에서 직접 끌어쓰지말기 
        //데이터만 가져오세요
        public List<GameObject> CharacterContainer;

        //캐릭터 정보 리스트
        public List<AgentDataSO> CharacterDataList;

        //캐릭터 스킬 정보 리스트
        public SkillManager SkillManager;

        private void Awake()
        { 
            SkillManager.GetCharacterDataManager(this);
        }

        public AgentDataSO GetCharacterDataById(CharacterID id)
        {
            foreach (var data in CharacterDataList)
            {
                if (data.ID == id)
                {
                    return data;
                }
            }
            return null;
        }
        public GameObject GetCharacterObjectById(CharacterID id)
        {
            foreach (var data in CharacterContainer)
            {
                if (data.GetComponentInChildren<Agent>().playerid == id)
                {
                    return data;
                }
            }
            return null;
        }

        public Agent GetCharacterAgentBYId(CharacterID id)
        {
            foreach (var data in CharacterContainer)
            {
                if (data.GetComponentInChildren<Agent>().playerid == id)
                {
                    return data.GetComponentInChildren<Agent>();
                }
            }
            return null;
        }
        
    }   
    public enum CharacterID
    {
        DemoPlayer,
        BlackPlayer,
        YellowPlayer,
        WhitePlayer,
        RedPlayer
    }
}
using System;
using UnityEngine;
using UniRx;
using Unity.VisualScripting;
using UnityEditor;

namespace Script.Client.Manager
{
    // 플레이어 데이터 : 로드와 온라인 상태의 플레이어 데이터를 관리할 뿐
    public class PlayerDataManager : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO PlayerData;

        public PlayerDataSO GetPlayerDataSO()
        {
            return PlayerData;
        }

        private void Awake()
        {
            if(PlayerPrefs.HasKey("PlayerID"))
                LOADMY();
        }

        private void Start()
        {
            SubscribePacketRecever(FindObjectOfType<PacketRecever>());
        }
        public void SubscribePacketRecever(PacketRecever recever)
        {
            recever.OnConnect.Subscribe(value => SetPlayerId(value.Id));
        }
        public void SetPlayerId(int id)
        {
            Debug.Log("Connect Event Handled");
            PlayerData.PlayerID = id;
        }
        public int GetPlayerId()
        {
            return PlayerData.PlayerID;
        }
        public void SelectCharacter(CharacterID id)
        {
            PlayerData.CharacterID = id;
        }
        public CharacterID GetSelectCharacter()
        {
            return PlayerData.CharacterID;
        }
        public void SelectControllObject(int id)
        {
            PlayerData.ControllingObjID = id;
        }
        public int GetControllObject()
        {
            return PlayerData.ControllingObjID;
        }

        public void SelectSkillInSlot(int slotnum, string data)
        {
            
            switch (slotnum)
            {
                case 1:
                    PlayerData.Slot1Data = data;
                    break;
                case 2:
                    PlayerData.Slot2Data = data;
                    break;
                case 3:
                    PlayerData.Slot3Data = data;
                    break;
                case 4:
                    PlayerData.Slot4Data = data;
                    break;
                case 5:
                    PlayerData.SelectedSupportData = data;
                    break;
            }
        }
        public string GetSkillInSlot(int slotnum)
        {
            switch (slotnum)
            {
                case 1:
                    return PlayerData.Slot1Data;
                    break;
                case 2:
                    return PlayerData.Slot2Data;
                    break;
                case 3:
                    return PlayerData.Slot3Data;
                    break;
                case 4:
                    return PlayerData.Slot4Data;
                    break;
            }
            Debug.Log("cannot found skill in slot");
            return null;
        }
        
        public void SelectSupportSkil(string data)
        {
            PlayerData.SelectedSupportData = data;
        }
        void OnApplicationQuit()
        {
            SAVEMY();
        }

        public void SetSO(PlayerDataSO so)
        {
            PlayerData = so;
        }

        public void SAVEMY()
        {
            Debug.Log("SAVEMY!!");
            PlayerPrefs.SetInt("PlayerID",PlayerData.PlayerID);
            PlayerPrefs.SetInt("CharacterID",(int)PlayerData.CharacterID);
            PlayerPrefs.SetString("Slot1Data",PlayerData.Slot1Data);
            PlayerPrefs.SetString("Slot2Data",PlayerData.Slot2Data);
            PlayerPrefs.SetString("Slot3Data",PlayerData.Slot3Data);
            PlayerPrefs.SetString("Slot4Data",PlayerData.Slot4Data);
            PlayerPrefs.SetString("SelectedSupportData",PlayerData.SelectedSupportData);
            PlayerPrefs.Save();
            
        }

        
        public void LOADMY()
        {
            PlayerData.PlayerID = PlayerPrefs.GetInt("PlayerID");
            PlayerData.CharacterID = (CharacterID)PlayerPrefs.GetInt("CharacterID");
            PlayerData.Slot1Data = PlayerPrefs.GetString("Slot1Data");
            PlayerData.Slot2Data = PlayerPrefs.GetString("Slot2Data");
            PlayerData.Slot3Data = PlayerPrefs.GetString("Slot3Data");
            PlayerData.Slot4Data = PlayerPrefs.GetString("Slot4Data");
            PlayerData.SelectedSupportData = PlayerPrefs.GetString("SelectedSupportData");
            
        }
    }
}
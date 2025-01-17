using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Script.Client.Scene;
using UniRx;
using Google.Protobuf.Protocol;

namespace Script.Client.Manager.SceneManager
{
    public class MatchingSceneManager : SceneControlManager
    {
        //HandleMatching
        public Text MachingStatusText;
        private void Start()
        {
            SubscribePacketRecever(FindObjectOfType<PacketRecever>());
            StartMaching();
            CountTime();
        }

        private IDisposable dis1;
        public void SubscribePacketRecever(PacketRecever recever)
        {
            dis1 = recever.OnStartGame.Subscribe(value => OnMached(value));
        }
        public void StartMaching()
        {
            //MachingStatusText.text = "Maching....";
            C_Matching pkt = new C_Matching();
            SkillInfo info = new SkillInfo();
            
            pkt.Id = MagicaClientMain.instance.playerDataManager.GetPlayerId();
            
            PlayerDataManager manager = MagicaClientMain.instance.playerDataManager;
            
            Skills skillid1 = (Skills)Enum.Parse(typeof(Skills), manager.GetSkillInSlot(1));
            info.ActiveSkill01 = (int)skillid1;
            Skills skillid2 = (Skills)Enum.Parse(typeof(Skills), manager.GetSkillInSlot(2));
            info.ActiveSkill02 = (int)skillid2;
            Skills skillid3 = (Skills)Enum.Parse(typeof(Skills), manager.GetSkillInSlot(3));
            info.ActiveSkill03 = (int)skillid3;
            Skills skillid4 = (Skills)Enum.Parse(typeof(Skills), manager.GetSkillInSlot(4));
            info.ActiveSkill04 = (int)skillid4;
            
            info.CharacterId = (int)manager.GetSelectCharacter();
            info.PassiveSkill = 0;
            pkt.Info = info;
            SendPacket(pkt);
        }
        
        public void OnMached(S_StartGame pkt)
        {
            if (pkt.Msg == "200")
            {
                dis1.Dispose();
                //MachingStatusText.text = "Mached!";
                Debug.Log("OnMatched?");
                MoveScene(_IngameScene);
            }
        }        
        
         public int sec = 0;
                public int min = 0;
                public void CountTime()
                {
                    StartCoroutine(Counting());
                }
        
                IEnumerator Counting()
                {
                    while (true)
                    {
                        yield return new WaitForSeconds(1f);
                        UpdateSec();         
                    }
               
                }
        
                public void UpdateMin()
                {
                    min++;
                }
        
                public void UpdateSec()
                {
                    sec++;
                    if (sec > 60)
                    {
                        sec = 0;
                        UpdateMin();
                    }
        
                    UpdateTimeText();
                }
        
                public Text timeText;
                public void UpdateTimeText()
                {
                    timeText.text = min + ":" + sec;
                }

                public void QuitGame()
                {
                    dis1.Dispose();
                    C_MatchingLeave pkt_ = new C_MatchingLeave();
                    pkt_.ObjectId = MagicaClientMain.instance.playerDataManager.GetPlayerId();
            
                    SendPacket(pkt_);
                    MoveScene(_LobbyScene);
                }
    }
}
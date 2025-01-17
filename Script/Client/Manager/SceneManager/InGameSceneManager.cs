using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Script.Client.Scene;
using Google.Protobuf.Protocol;
using Google.Protobuf.Collections;
using Script.Client.Core.Player;
using Script.Client.View;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Script.Client.Manager.SceneManager
{
    public class InGameSceneManager : SceneControlManager
    {
        public FollowCamera fcam;
        //네트워크 소환할 플레이어
        public GameObject PlayerContainer;
        public Camera _MainCamera;

        [Header("Test Object")] public GameObject TestPlayer;

        [Header("StartGameUI")] public GameObject OnGameStart;
        [Header("StartGameUI")] public GameObject OnGameStartPanel;
        [Header("EndGameUI")] public GameObject OnEndGamePanel;

        [Header("FailGameUI")] public GameObject OnGameFail;
        [Header("WinGameUI")] public GameObject OnGameWin;



        public static InGameSceneManager instance;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        private void Start()
        {
            OnGameStart.SetActive(true);
        }

        #region skill Inject

        private void OnGameWinHandler()
        {
            OnEndGamePanel.SetActive(true);
            StartCoroutine(WinGame());
        }

        IEnumerator WinGame()
        {
            yield return new WaitForSeconds(3f);
            OnGameFail.SetActive(false);
            OnGameWin.SetActive(true);
        }

        private void OnGameLoseHadler()
        {
            OnEndGamePanel.SetActive(true);
            StartCoroutine(LoseGame());
            
        }
        IEnumerator LoseGame()
        {
            yield return new WaitForSeconds(3f);
            OnGameFail.SetActive(true);
            OnGameWin.SetActive(false);
        }

        private void InjectQSkill(GameObject player,Skills id)
        {
            SkillManager skillManager = FindObjectOfType<SkillManager>();
            GameObject skill = Instantiate(skillManager.GetChargedSkill(id));
            Skill _skill = skill.GetComponent<Skill>();
            player.GetComponentInChildren<Agent>().agentSkill.InitQSkills(
                _skill
                );
            skill.transform.SetParent(player.GetComponentInChildren<Agent>().SKillCharger, false);
        }
        private void InjectWSkill(GameObject player,Skills id)
        {
            SkillManager skillManager = FindObjectOfType<SkillManager>();
            GameObject skill = Instantiate(skillManager.GetChargedSkill(id));
            Skill _skill = skill.GetComponent<Skill>();
            player.GetComponentInChildren<Agent>().agentSkill.InitWSkills(
                _skill
            );
            skill.transform.SetParent(player.GetComponentInChildren<Agent>().SKillCharger, false);
        }
        private void InjectESkill(GameObject player,Skills id)
        {
            SkillManager skillManager = FindObjectOfType<SkillManager>();
            GameObject skill = Instantiate(skillManager.GetChargedSkill(id));
            Skill _skill = skill.GetComponent<Skill>();
            player.GetComponentInChildren<Agent>().agentSkill.InitESkills(
                _skill
            );
            skill.transform.SetParent(player.GetComponentInChildren<Agent>().SKillCharger, false);
        }
        private void InjectRSkill(GameObject player,Skills id)
        {
            SkillManager skillManager = FindObjectOfType<SkillManager>();
            GameObject skill = Instantiate(skillManager.GetChargedSkill(id));
            Skill _skill = skill.GetComponent<Skill>();
            player.GetComponentInChildren<Agent>().agentSkill.InitRSkills(
                _skill
            );
            skill.transform.SetParent(player.GetComponentInChildren<Agent>().SKillCharger, false);
        }
        #endregion
        
        /// <summary>
        /// String : id
        /// NetworkObjectData : Datas
        /// </summary>
        public List<GameObject> NetworkObjects = new List<GameObject>();
        public GameObject NetworkObjectField;

        
        protected override void SceneWasLoadedHandler(object argument) 
        {
            MagicaClientMain.instance.cameraManager.SetInGameSceneCamera(_MainCamera);
            SubscribePacketRecever(FindObjectOfType<PacketRecever>());
            
            C_SceneLoadEnd pkt = new C_SceneLoadEnd();
            pkt.Msg = MagicaClientMain.instance.playerDataManager.GetPlayerId().ToString();
            SendPacket(pkt);
            
            Debug.Log("--Send C_LoadEnd--");
        }
        
        public void OnAllPlayerLoaded(S_SceneLoadEnd value)
        {
            if (value.Msg != "200")
            {
                Debug.Log("Vaild packet!");
                return;
            }
            //Debug.Log($"value.msg : {value.Msg}");
            //Debug.Log("Send C_EnterGame");
            
            C_EnterGame pkt = new C_EnterGame();
            pkt.Msg = MagicaClientMain.instance.playerDataManager.GetPlayerId().ToString();
            SendPacket(pkt);
        }

        private IDisposable sub1;
        private IDisposable sub2;
        private IDisposable sub3;
        private IDisposable sub4;
        private IDisposable sub5;
        private IDisposable sub6;
        public void SubscribePacketRecever(PacketRecever recever)
        {
            //OnGameStart.SetActive(false);
            sub1 = recever.OnAllLoaded.AsObservable().Subscribe(value => OnAllPlayerLoaded(value));
            sub2 = recever.OnEnterGame.AsObservable().Subscribe(value => SetNetworkObejct(value));
            sub3 = recever.OnEnterGame.AsObservable().Subscribe(value =>StartCoroutine(OpenGame(value)));
            sub4 = recever.OnSpawn.AsObservable().Subscribe(value => SetNetworkObejct(value));
            sub5 = recever.OnHit.AsObservable().Subscribe(value => SetHP(value));
            sub6 = recever.OnWin.AsObservable().Subscribe(value => WinCheck(value));

        }
        IEnumerator OpenGame(S_EnterGame value)
        {
            
            if (value == null)
            {
                yield break;
            }
            if (value.ObjInfo == null)
                yield break;

            CountTime();
            OnGameStart.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            OnGameStartPanel.SetActive(true);
            yield return new WaitForSeconds(3f);
          
            OnGameStartPanel.SetActive(false);
        }
        public void WinCheck(S_Win value)
        {
            if (value == null)
            {
                return;
            }

            if (value.ObjectId == 0)
            {
                return;
            }

            sub1.Dispose();
            sub2.Dispose();
            sub3.Dispose();
            sub4.Dispose();
            sub5.Dispose();
            sub6.Dispose();
            
            if (value.ObjectId != MagicaClientMain.instance.playerDataManager.GetPlayerId())
            {
                OnGameLoseHadler();
               // OnGameWinHandler();
               C_LeaveGame pkt_ = new C_LeaveGame();
               pkt_.ObjectId = MagicaClientMain.instance.playerDataManager.GetPlayerId();
            
               SendPacket(pkt_);
               StartCoroutine(OutGame());
                return;
            }

            OnGameWinHandler();

            C_LeaveGame pkt = new C_LeaveGame();
            pkt.ObjectId = MagicaClientMain.instance.playerDataManager.GetPlayerId();
            
            SendPacket(pkt);
            
            StartCoroutine(OutGame());
        }

        IEnumerator OutGame()
        {
            yield return new WaitForSeconds(8f);
            MoveScene(_LobbyScene);
        }
        public void SetHP(S_Hit pkt)
        {
            Debug.Log("packet RECVED?");
            if (pkt.ObjInfo == null)
            {
                return;
            }
            
            Debug.Log("on Damage Invoke");
            // ISMine
            if (pkt.ObjInfo.ObjectId == MagicaClientMain.instance.playerDataManager.GetPlayerId())
            {
                playercanvas.SetPlayerHP(pkt.Damage);
                InGameSceneView.instance.OnHpChanged(pkt.Damage);
            }
            else
            {
                enemycanvas.SetPlayerHP(pkt.Damage);
            }
        }
        //S_EnterGame == 내 오브젝트 생성
        public void SetNetworkObejct(S_EnterGame value)
        { 
            Debug.Log("SetNetworkObejct?");

            MyPlayerid = (CharacterID)value.MyCharacterId;
            Enemyid = (CharacterID)value.EnemyCharacterId;
            if ( value.ObjInfo == null)
                return;
            
            Debug.Log($"S_Enter Pos info { value.ObjInfo.PosInfo.PosX},{value.ObjInfo.PosInfo.PosY}");;
            Debug.Log("EnterGame 패킷에서 왔어요");
            SpawnNetworkObject(value.ObjInfo);
        }
        
        public void SetNetworkObejct(S_Spawn pkt)
        {
            //Debug.Log("SetNetworkObejct?");

            RepeatedField<ObjectInfo> objInfo = pkt.ObjInfos;
        
            if(objInfo==null)
                return;
            
            foreach (ObjectInfo obj in objInfo)
            {
                Debug.Log($"S_Spawn Pos info {obj.PosInfo.PosX},{obj.PosInfo.PosY}");;
                Debug.Log("Spawn 패킷에서 왔어요");
                SpawnNetworkObject(obj);
            }
        }

        private void SpawnNetworkObject(ObjectInfo info)
        {
            //Debug.Log("SetNetworkObject");
            GameObjectType objtype = NetworkObjectManager.GetObjectTypeById(info.ObjectId);
            switch (objtype)
            {
                case GameObjectType.Player:
                    SetNetworkPlayer(info);
                    break;
                case GameObjectType.Monster:
                    SetNetworkMonster(info);
                    break;
                case GameObjectType.Projectile:
                    SetNetworkProjecttile(info);
                    break;
                case GameObjectType.None:
                    break;
            }
        }

        /// <summary>
        /// 네트워크 플레이어를 생성 
        /// </summary>
        /// <param name="info">플레이어의 정보</param>
        public CharacterID MyPlayerid;
        public CharacterID Enemyid;
        public AgentCanvas playercanvas;
        public AgentCanvas enemycanvas;
        private void SetNetworkPlayer(ObjectInfo info)
        {
            //CharacterID
            GameObject player;
            //Debug.Log(MyPlayerid);
            //Debug.Log(Enemyid);
            //obejct info에 캐릭터 필요
            Debug.Log($"캐릭터 생성 오브젝트 ID : {info.ObjectId}");
            if (info.ObjectId == MagicaClientMain.instance.playerDataManager.GetPlayerId())
            {
                 Debug.Log(MyPlayerid);
                 InGameSceneView.instance.ChangePlayerName(GetCoreName((int)MyPlayerid));
                 InGameSceneView.instance.ChangeMyIcon(MyPlayerid);
                 player =
                    Instantiate(MagicaClientMain.instance.characterDataManager.GetCharacterObjectById(MyPlayerid));
                 NavMeshAgent agent = player.GetComponentInChildren<NavMeshAgent>();
                 agent.enabled = false;
                 agent.avoidancePriority = 51;
                 fcam.target = player.GetComponentInChildren<Agent>().transform;
                 //player.GetComponentInChildren<Agent>().canvas.SetPlayerHP();
                 player.GetComponentInChildren<Agent>().canvas.OnMe();
                 playercanvas = player.GetComponentInChildren<Agent>().canvas;
            }
            else
            {                   
                 InGameSceneView.instance.ChangeEnemyName(GetCoreName((int)Enemyid));
                 InGameSceneView.instance.ChangeEnemyIcon(Enemyid);
                 Debug.Log(Enemyid);
                 player =
                    Instantiate(MagicaClientMain.instance.characterDataManager.GetCharacterObjectById(Enemyid));
                 NavMeshAgent agent = player.GetComponentInChildren<NavMeshAgent>();
                 agent.enabled = false;
                 agent.avoidancePriority = 50;
                 player.GetComponentInChildren<Agent>().canvas.OnEnemy();
                 enemycanvas = player.GetComponentInChildren<Agent>().canvas;
            }
            NetworkObjectData data = player.GetComponent<NetworkObjectData>();
            data.Objid = info.ObjectId;
            data.StartPos = new Vector3(info.PosInfo.PosX, 1, info.PosInfo.PosY);
            player.GetComponentInChildren<Agent>().transform.position = data.StartPos;
            player.transform.SetParent(NetworkObjectField.transform,false);
            
            NetworkAgentInput inputter = player.GetComponentInChildren<NetworkAgentInput>();
            
            inputter.SubscribePacketRecever(FindObjectOfType<PacketRecever>());
            NetworkObjects.Add(player);
            player.GetComponentInChildren<NavMeshAgent>().enabled = true;
          
            // ISMine
            if (info.ObjectId == MagicaClientMain.instance.playerDataManager.GetPlayerId())
            {
                PlayerDataManager manager = MagicaClientMain.instance.playerDataManager;
                manager.SelectControllObject(info.ObjectId);
                Skills skillid = (Skills)Enum.Parse(typeof(Skills), manager.GetSkillInSlot(1));
                InjectQSkill(player,skillid);
                InGameSceneView.instance.ChangeSKilQ(manager.GetSkillInSlot(1));
                Skills skillid2 = (Skills)Enum.Parse(typeof(Skills), manager.GetSkillInSlot(2));
                InjectWSkill(player,skillid2);
                InGameSceneView.instance.ChangeSKilW(manager.GetSkillInSlot(2));
                Skills skillid3 = (Skills)Enum.Parse(typeof(Skills), manager.GetSkillInSlot(3));
                InjectESkill(player,skillid3);
                InGameSceneView.instance.ChangeSKilE(manager.GetSkillInSlot(3));
                Skills skillid4 = (Skills)Enum.Parse(typeof(Skills), manager.GetSkillInSlot(4));
                InjectRSkill(player,skillid4);
                InGameSceneView.instance.ChangeSKilR(manager.GetSkillInSlot(4));

                InGameSceneView.instance.ChangeSKilT(manager.GetPlayerDataSO().SelectedSupportData);

                
                
            }
            
            
        }
        
        public static string CoreJsonPath = "DeckBuildSceneCore";
        public string GetCoreName(int ID)
        {
            CoreData data = JsonUtility.FromJson<CoreData>(LoadTextPack(CoreJsonPath).ToString());
            //Debug.Log(data.Cores.Count);
            foreach (var var in data.Cores)
            {
                if (ID.ToString() == var.CoreID.ToString())
                {
                    return var.CoreName;
                }
            }
            Debug.Log("NO CHAR NAME!!!");
            return null;
        }  
        public string GetCoreIConPath(int ID)
        {
            CoreData data = JsonUtility.FromJson<CoreData>(LoadTextPack(CoreJsonPath).ToString());
            //Debug.Log(data.Cores.Count);
            foreach (var var in data.Cores)
            {
                if (ID.ToString() == var.CoreID.ToString())
                {
                    return var.CoreID;
                }
            }
            Debug.Log("NO CHAR NAME!!!");
            return null;
        }  
        public static string CombatJsonPath = "DeckBuildSceneCombat";
        //스킬경로 가져오기
        public string GetSkillPath(Skills ID)
        {
            CombatData data = JsonUtility.FromJson<CombatData>(LoadTextPack(CombatJsonPath).ToString());
           
            foreach (var var in data.CombatSkills)
            {
                if (ID.ToString() == var.SkillCode.ToString())
                {
                    return var.ImageID;
                }
            }
            Debug.Log("NO CHAR NAME!!!");
            return null;
        } 
        
        public TextAsset LoadTextPack(string path)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(path);
            //string Text = JsonUtility.FromJson<string>(textAsset.text);
            return textAsset;
        }
        
        private void SetNetworkMonster(ObjectInfo info)
        {
            

        }

        
        private void SetNetworkProjecttile(ObjectInfo info)
        { 
            SkillManager skillManager = FindObjectOfType<SkillManager>();
            
            Skills id = (Skills)NetworkObjectManager.GetSkillIdById(info.ObjectId);
            //info.TargetInfo.
            
            //Debug.Log(info.ObjectId);
            //Debug.Log(info.PosInfo);
            GameObject obj;
            Debug.Log($"skill obj id  : {id}");
            obj = Instantiate(skillManager.GetChargedSkillOBJ(id));
            obj.transform.position = new Vector3(info.PosInfo.PosX,1,info.PosInfo.PosY);
            obj.transform.SetParent(NetworkObjectField.transform,false);
            obj.GetComponent<NetworkObjectData>().Objid = info.ObjectId;
            obj.GetComponent<SkillObj>().TargetPos = new  Vector3(info.TargetInfo.PosX,1,info.TargetInfo.PosY);
            NetworkObjects.Add(obj);
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

        public void DeleteObject(S_Despawn pkt)
        {
            Debug.Log("Try Delete");
            List<GameObject> delete = new List<GameObject>();
            foreach (var id in pkt.ObjectIds)
            {
                Debug.Log($"to delete id is: {id}");
                foreach (var obj in NetworkObjects)
                {
                    if(obj==null)
                        continue;
                    if (obj.GetComponent<NetworkObjectData>().Objid == id)
                    {
                        Debug.Log("Found del obj");
                        delete.Add(obj);
                        continue;
                    }
                    if (obj.GetComponentInChildren<NetworkObjectData>().Objid == id)
                    {
                        Debug.Log("Found del obj");
                        delete.Add(obj);
                        continue;
                    }
                }
            }

            foreach (var del in delete)
            {
                Destroy(del);    
            }
        }
        
        
        //DATA-SET-FIELD
        [System.Serializable]
        public class CoreData
        {
            public List<CoreTextData> Cores;
        }  
        [System.Serializable]
        public class CoreTextData
        {
            public  string CoreID;
            public  string CoreName;
            public  string CoreNameSub;
            public  string CoreNameExplain;
            public  string ExplainText_1;
            public  string ExplainText_2;
        }
        [System.Serializable]
        public class CombatData
        {
            public List<CombatSkillData> CombatSkills;
        }
        
        [System.Serializable]
        public class CombatSkillData
        {  
            public string SkillName;
            public string SKillID;
            public string SkillCode;
        
            public string SkillTitle;
            public string SkillExplain;
            public string SkillSubTitle;
            public string SkillSubExplain;
            public string ImageID;
        }
    }
    
}
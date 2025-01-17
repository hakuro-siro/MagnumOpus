using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Script.Client.Manager.SceneManager;
using UnityEngine;

namespace Script.Client.Manager
{
    public class MagicaClientMain : MonoBehaviour
    {
        public static MagicaClientMain instance = null;
        // DontDestroy
        [SerializeField] private List<GameObject> dontDestroyObjects;
        // GlobalManagers
        [SerializeField] internal PlayerDataManager playerDataManager;
        [SerializeField] internal CharacterDataManager characterDataManager;
        [SerializeField] internal SoundManager soundManager;
        [SerializeField] internal NetworkManager networkManager;
        [SerializeField] internal PacketRecever packetRecever;
        [SerializeField] internal CameraManager cameraManager;
        // LocalManagers
        [SerializeField]
        private SceneControlManager activeControlManager;

        public Camera cam;
        /// <summary>
        /// Start Of Client Main
        /// </summary>

        #region  Only Call Once : Game Call Main
        private void Awake()
        {            
            Debug.Log("--Init Magica Client Main--");
            if (instance == null)
            {
                instance = this;
            }
            playerDataManager = FindObjectOfType<PlayerDataManager>();
            soundManager = FindObjectOfType<SoundManager>();
            networkManager = FindObjectOfType<NetworkManager>();
            characterDataManager = FindObjectOfType<CharacterDataManager>();
            activeControlManager = FindObjectOfType<SceneControlManager>();
            packetRecever = FindObjectOfType<PacketRecever>();
            cameraManager = FindObjectOfType<CameraManager>();
            packetRecever.SubscribePacketHandler();
            DontDestroySetting();
        }
        
        private void DontDestroySetting()
        {
            foreach (var obj in dontDestroyObjects)
            {
                DontDestroyOnLoad(obj);
            }
            DontDestroyOnLoad(this.gameObject);
        }
        
        private void Start()
        {
            GameStart();
        }
        private void GameStart()
        {
            activeControlManager.GameStartCall();
        }
        #endregion
        
        
        /// <summary>
        /// 씬 변경되었을때의 이벤트 상태를 체크하기 위함.
        /// </summary>
        /// <param name="controlmanager"></param>
        public void InvokeOnControlManagerChanged(SceneControlManager controlmanager)
        {
            activeControlManager = controlmanager;
            ManagerConfirmCheck();
        }

        private void ManagerConfirmCheck()
        {
            activeControlManager.OnClientMainCheckCall();
        }
       
    }
    
}
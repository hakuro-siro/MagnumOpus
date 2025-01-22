using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace Script.Client.Manager.SceneManager
{
    public class BootSceneManager : SceneControlManager
    {
        /// <summary>
        /// 게임 시작 핸들링
        /// </summary>
          protected override void OnGameStartCall()
        {
            Debug.Log("--GameStart--");
            Debug.Log("--BootScene--");
            //MoveScene(_TitleScene);
        }
        public VideoPlayer videoPlayer;
        private void Start()
        {
            videoPlayer.loopPointReached += EndReached;
        }

        void EndReached(UnityEngine.Video.VideoPlayer vp)
        {
            videoPlayer.loopPointReached -= EndReached;
            MoveScene(_LobbyScene);
        }
        
    }
}
using System;
using UnityEngine;
using Script.Client.Scene;
using UnityEngine.Video;

namespace Script.Client.Manager.SceneManager
{
    public class TitleSceneManager : SceneControlManager
    {
        //On This Scene LoadEnd!
        protected override void SceneWasLoadedHandler(object argument)
        {
            base.SceneWasLoadedHandler(argument);
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Script.Client.UI;

namespace Script.Client.Manager.SceneManager
{
    public class LoadSceneManager : SceneControlManager
    {

        [SerializeField]
        private LoadingBar loadingBar;
        [SerializeField]
        private float BasicLoadTime = 0.2f;
        [SerializeField]
        string DesireScene;

        public bool LoadBarEnd;
        public bool DesireLoadEnd;

        protected override void SceneWasLoadedHandler(object argument)
        {
            DesireScene = "";
            Debug.Log("--LoadScene--");
            Debug.Log($"Load Scene => Desire Scene Is : **{argument}**");
            Debug.Log($"Load Scene => Desire Scene : **{DesireScene}**");
            switch (argument)
            {
                case "TitleScene":
                    DesireScene = _TitleScene;
                    LoadTitleScene();
                    break;
                case "LobbyScene":
                    DesireScene = _LobbyScene;
                    LoadLobbyScene();
                    break;
                case "MatchingScene":
                    DesireScene = _MatchingScene;
                    LoadMatchingScene();
                    break;
                case "DeckBuildScene":
                    DesireScene = _DeckBuildScene;
                    LoadMatchingScene();
                    break;
                case "InGameScene":
                    DesireScene = _IngameScene;
                    LoadMatchingScene();
                    break;
            }
            Debug.Log($"Break!");
            Debug.Log($"Break Desire Scene : **{DesireScene}**");

        }
        private void LoadLobbyScene()
        {
            MagicaClientMain.instance.cam.enabled = true;
            LoadStart();
        }
        private void LoadTitleScene()
        {
            LoadStart();
        }       
        private void LoadMatchingScene()
        {      
            LoadStart();
        }
        private void LoadInGameScene()
        {
            LoadStart();
        }
        
        private void LoadStart()
        {
            Debug.Log($"StartLoading");

            loadingBar.OnLoadBarEnd += OnLoadBarEnd;
            loadingBar.LoadBarStart(BasicLoadTime);
            StartCoroutine(WaitForLoadEnd());
        }

        private void OnLoadBarEnd()
        {
            LoadBarEnd = true;
        }

        IEnumerator WaitForLoadEnd()
        {
            while (true)
            {
                if (LoadBarEnd)
                {
                    LoadEnd();
                    break;
                }
                yield return null;
            }
        }
        private void LoadEnd()
        {
            Debug.Log("Load Scene => SceneLoadEnd!");
            SceneChangeCall();
        }
        public void SceneChangeCall()
        {
            PacketRecever recever = FindObjectOfType<PacketRecever>();
            recever.ClearRecever();
            SceneManagerEx.LoadSceneWithArg(DesireScene, null, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }


    }
}
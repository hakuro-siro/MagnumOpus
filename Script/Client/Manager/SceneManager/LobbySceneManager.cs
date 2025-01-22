using UnityEngine;
using Script.Client.Scene;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UniRx;
using Script.Client.UI;
using Script.Client.UI.LobbyScene;

namespace Script.Client.Manager.SceneManager
{
    /// <summary>
    /// UniRX MVP Presenter
    /// </summary>
    public class LobbySceneManager : SceneControlManager
    {
        public LobbySceneView View;
        public LobbySceneModel Model;

        //On This Scene LoadEnd!
        protected override void SceneWasLoadedHandler(object argument)
        {
            base.SceneWasLoadedHandler(argument);
        }


        private void Start()
        {
            ModelViewInit();
        }

        public void ModelViewInit()
        {
            //View => Model 
            View.BindEvent(LobbyScene.Buttons.OpenSettingButton,View.OpenPanel,
                LobbyScene.Pannels.SettingPannel
            );
            View.BindEvent(LobbyScene.Buttons.CloseSettingButton,View.ClosePanel,
                LobbyScene.Pannels.SettingPannel
            );
            View.BindEvent(LobbyScene.Buttons.MachingButton,GotoMatchRoom);
            View.BindEvent(LobbyScene.Buttons.DeckBuildingButton,GotoDeckBuildRoom);
        }


        //Scene Changer
        public void GotoMatchRoom()
        {
            MoveScene(_MatchingScene);
        }
        public void GotoDeckBuildRoom()
        {
            MoveScene(_DeckBuildScene);
        }   
        public void OnClickClose()
        {
            Application.Quit();
        }
        
        
        
        
        
    }
}
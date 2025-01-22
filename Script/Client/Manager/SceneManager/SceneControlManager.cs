using System;
using UnityEngine;
using Script.Client.Scene;
using UnityEngine.SceneManagement;
using Core;
using UniRx;
using Google.Protobuf.Protocol;

namespace Script.Client.Manager.SceneManager
{
    /// <summary>
    /// SceneControl Manager �� Presenter�� ������ �����մϴ�
    /// </summary>
    public class SceneControlManager : MonoBehaviour, ISceneWasLoaded
    {
        #region  Call Only Once :Game Starter
        public void GameStartCall()
        {
            OnGameStartCall();
        }
        protected virtual void OnGameStartCall()
        {
            
        }
        #endregion

        
        /// <summary>
        /// Scene Pos 
        /// </summary>
        protected string _LoadScene =      "LoadScene";
        protected string _LobbyScene =     "LobbyScene";
        protected string _BootScene =      "TitleScene";
        protected string _TitleScene =     "TitleScene";
        protected string _MatchingScene =  "MatchingScene";
        protected string _IngameScene =    "InGameScene";
        protected string _DeckBuildScene =  "DeckBuildScene";

        /// <summary>
        /// Scene Load�� Invoke
        /// </summary>
        /// <param name="argument"> ���� ������ ������ ������ </param>
        public void OnSceneWasLoaded(object argument)
        {
            //Debug.Log("OnSceneWasLoaded.");
            SceneWasLoadedHandler(argument);
            MagicaClientMain.instance.InvokeOnControlManagerChanged(this);
        }
        //Argument �� ������ �ʿ��� ���
        protected virtual void  SceneWasLoadedHandler(object argument)
        {
            
        }
        /// <summary>
        /// Ŭ���̾�Ʈ ���ο��� �� ���� Manager Ȯ���� ���� ������ ó�� **�ش� �ڵ� ȣ�� ���ķδ� ClientMain Call �� ������**
        /// </summary>
        public void OnClientMainCheckCall()
        {
            Debug.Log($"Client Main Call => Scene Controller is **{this.gameObject.name}**");
        }

        /// <summary>
        /// ��Ŷ �۽ź�
        /// </summary>
        /// <param name="packet"></param>
#region Send Packet
        protected virtual void SendPacket(object packet)
        {
            if (packet as C_Matching != null)
            {
                C_Matching pkt = packet as C_Matching;
                NetworkManager.Instance.Send(pkt);
            }
            if (packet as C_EnterGame != null)
            {
                C_EnterGame pkt = packet as C_EnterGame;
                NetworkManager.Instance.Send(pkt);
            }
            if (packet as C_SceneLoadEnd != null)
            {
                C_SceneLoadEnd pkt = packet as C_SceneLoadEnd;
                NetworkManager.Instance.Send(pkt);
            }
            if (packet as C_LeaveGame != null)
            {
                C_LeaveGame pkt = packet as C_LeaveGame;
                NetworkManager.Instance.Send(pkt);
            }
            if (packet as C_MatchingLeave != null)
            {
                C_MatchingLeave pkt = packet as C_MatchingLeave;
                NetworkManager.Instance.Send(pkt);
            }
        }
#endregion



        public void MoveScene(string desireScene)
        {
            
            SceneManagerEx.LoadSceneWithArg(
                _LoadScene,
                desireScene,
                LoadSceneMode.Single);
            
        }
        


    }
  
}
using System;
using Google.Protobuf.Protocol;
using Mono.CSharp.Linq;
using UnityEngine;
using Script.Client.Scene;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UniRx;
using Script.Client.UI;
using Script.Client.UI.DeckBuildScene;
using Script.Client.UI.LobbyScene;
using UnityEditor;

namespace Script.Client.Manager.SceneManager
{
    /// <summary>
    /// UniRX MVP Presenter
    /// </summary>
    public class DeckBuildSceneManager : SceneControlManager
    {
        public DeckBuildSceneView View;

        public PlayerDataManager Playerdatamanager;
        
        public string slot1;
        public string slot2;
        public string slot3;
        public string slot4;
        public string slot5;
        public CharacterID charid;

        
        //public LobbySceneModel Model;

        //On This Scene LoadEnd!
        
        protected override void SceneWasLoadedHandler(object argument)
        {
            base.SceneWasLoadedHandler(argument);
        }

        private void Awake()
        {
            Playerdatamanager = FindObjectOfType<PlayerDataManager>();
           
        }

        private void Start()
        {
            SetPacks();
            ModelViewInit();
            //DebugOption();
            SettingMyEnterData();
            SettingMySet();
        }
        private void SettingMyEnterData()
        {
            slot1 = Playerdatamanager.GetPlayerDataSO().Slot1Data;
            slot2 = Playerdatamanager.GetPlayerDataSO().Slot2Data;
            slot3 = Playerdatamanager.GetPlayerDataSO().Slot3Data;
            slot4 = Playerdatamanager.GetPlayerDataSO().Slot4Data;
            slot5 = Playerdatamanager.GetPlayerDataSO().SelectedSupportData;
            
            charid = Playerdatamanager.GetPlayerDataSO().CharacterID;
            
        }
        private void DebugOption()
        {
            View.CleanSlot();
            View.BindOnClick(DeckBuildScene.Buttons.CoreSlot_Button_1);
            SelectCharacter(CharacterID.BlackPlayer);
            View.SetCoreExplainText(1);
        }

            
        public void SetPacks()
        {
            //MenuButtons
            View.Packing(View.MenuButtons,(int)DeckBuildScene.Buttons.Button_CoreMenu);
            View.Packing(View.MenuButtons,(int)DeckBuildScene.Buttons.Button_CombatMenu);
            View.Packing(View.MenuButtons,(int)DeckBuildScene.Buttons.Button_SupportMenu);
            foreach (var Code in View.MenuButtons)
            {
                View.GetButton((DeckBuildScene.Buttons)Code).ButtonType = Code;
            }
            
            //MenuPanels
            View.Packing(View.MenuPanels,(int)DeckBuildScene.Pannels.CORE);
            View.Packing(View.MenuPanels,(int)DeckBuildScene.Pannels.COMBAT);
            View.Packing(View.MenuPanels,(int)DeckBuildScene.Pannels.SUPPORT);
            //CoreSlot
            View.Packing(View.CoreButtons,(int)DeckBuildScene.Buttons.CoreSlot_Button_1);
            View.Packing(View.CoreButtons,(int)DeckBuildScene.Buttons.CoreSlot_Button_2);
            View.Packing(View.CoreButtons,(int)DeckBuildScene.Buttons.CoreSlot_Button_3);
            View.Packing(View.CoreButtons,(int)DeckBuildScene.Buttons.CoreSlot_Button_4);
            foreach (var Code in View.CoreButtons)
            {
                View.GetButton((DeckBuildScene.Buttons)Code).ButtonType = Code;
            }
            View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button1);
            View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button2);
            View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button3);
            View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button4);
            View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button5);
            View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button6);
            View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button7);
            View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button8);
            View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button9);
            View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button10);
            View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button11);
            View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button12);
            View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button13);
            View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button14);
            // View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button15);
            // View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button16);
            // View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button17);
            // View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button18);
            // View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button19);
            // View.Packing(View.CombatButtons,(int)DeckBuildScene.Buttons.SkillSlot_Button20);
            foreach (var Code in View.CombatButtons)
            {
                View.GetButton((DeckBuildScene.Buttons)Code).ButtonType = Code;
            }
            View.Packing(View.SlotButtons,(int)DeckBuildScene.Buttons.Content_Equip_Skill_0);
            View.Packing(View.SlotButtons,(int)DeckBuildScene.Buttons.Content_Equip_Skill_1);
            View.Packing(View.SlotButtons,(int)DeckBuildScene.Buttons.Content_Equip_Skill_2);
            View.Packing(View.SlotButtons,(int)DeckBuildScene.Buttons.Content_Equip_Skill_3);
            View.Packing(View.SlotButtons,(int)DeckBuildScene.Buttons.Content_Equip_Skill_4);
            View.Packing(View.SlotButtons,(int)DeckBuildScene.Buttons.Content_Equip_Skill_5);
            foreach (var Code in View.SlotButtons)
            {
                View.GetButton((DeckBuildScene.Buttons)Code).ButtonType = Code;
            }
//            SlotImages
            View.Packing(View.SlotImages,(int)DeckBuildScene.Images.Content_Equip_Skill_0);
            View.Packing(View.SlotImages,(int)DeckBuildScene.Images.Content_Equip_Skill_1);
            View.Packing(View.SlotImages,(int)DeckBuildScene.Images.Content_Equip_Skill_2);
            View.Packing(View.SlotImages,(int)DeckBuildScene.Images.Content_Equip_Skill_3);
            View.Packing(View.SlotImages,(int)DeckBuildScene.Images.Content_Equip_Skill_4);
            View.Packing(View.SlotImages,(int)DeckBuildScene.Images.Content_Equip_Skill_5);

        }
        public void ModelViewInit()
        {
            //View => Model 

            //MenuButtons
            #region MenuButtons

            
            #region Button_CoreMenu
            View.BindEvent(DeckBuildScene.Buttons.Button_CoreMenu,View.BindOnClick,
                DeckBuildScene.Buttons.Button_CoreMenu
            );
            View.BindEvent(DeckBuildScene.Buttons.Button_CoreMenu,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.Button_CoreMenu,View.MenuButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.Button_CoreMenu,View.OpenPanel,
                DeckBuildScene.Pannels.CORE
            );
            View.BindEvent(DeckBuildScene.Buttons.Button_CoreMenu,View.CloseMainPanelWithOutMe,
                DeckBuildScene.Pannels.CORE
            );
            #endregion

            #region Button_CombatMenu
            View.BindEvent(DeckBuildScene.Buttons.Button_CombatMenu,View.BindOnClick,
                DeckBuildScene.Buttons.Button_CombatMenu
            );
            View.BindEvent(DeckBuildScene.Buttons.Button_CombatMenu,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.Button_CombatMenu,View.MenuButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.Button_CombatMenu,View.OpenPanel,
                DeckBuildScene.Pannels.COMBAT
            );
            View.BindEvent(DeckBuildScene.Buttons.Button_CombatMenu,View.CloseMainPanelWithOutMe,
                DeckBuildScene.Pannels.COMBAT
            );
            #endregion

            #region Button_SupportMenu
            View.BindEvent(DeckBuildScene.Buttons.Button_SupportMenu,View.BindOnClick,
                DeckBuildScene.Buttons.Button_SupportMenu
            );
            View.BindEvent(DeckBuildScene.Buttons.Button_SupportMenu,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.Button_SupportMenu,View.MenuButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.Button_SupportMenu,View.OpenPanel,
                DeckBuildScene.Pannels.SUPPORT
            );
            View.BindEvent(DeckBuildScene.Buttons.Button_SupportMenu,View.CloseMainPanelWithOutMe,
                DeckBuildScene.Pannels.SUPPORT
            );
            #endregion
            
            
            #endregion

            #region CoreButtons
            
            View.BindEvent(DeckBuildScene.Buttons.CoreSlot_Button_1,View.BindOnClick,
                DeckBuildScene.Buttons.CoreSlot_Button_1
            );
            View.BindEvent(DeckBuildScene.Buttons.CoreSlot_Button_2,View.BindOnClick,
                DeckBuildScene.Buttons.CoreSlot_Button_2
            );
            View.BindEvent(DeckBuildScene.Buttons.CoreSlot_Button_3,View.BindOnClick,
                DeckBuildScene.Buttons.CoreSlot_Button_3
            );
            View.BindEvent(DeckBuildScene.Buttons.CoreSlot_Button_4, View.BindOnClick,
                DeckBuildScene.Buttons.CoreSlot_Button_4
            );
            View.BindEvent(DeckBuildScene.Buttons.CoreSlot_Button_1,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.CoreSlot_Button_1,View.CoreButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.CoreSlot_Button_2,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.CoreSlot_Button_2,View.CoreButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.CoreSlot_Button_3,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.CoreSlot_Button_3,View.CoreButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.CoreSlot_Button_4,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.CoreSlot_Button_4,View.CoreButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.CoreSlot_Button_1,View.SetCoreExplainText,
                1
            );
            View.BindEvent(DeckBuildScene.Buttons.CoreSlot_Button_1,SelectCharacter,
                CharacterID.BlackPlayer
            );
            View.BindEvent(DeckBuildScene.Buttons.CoreSlot_Button_2,View.SetCoreExplainText,
                2
            );
            View.BindEvent(DeckBuildScene.Buttons.CoreSlot_Button_2,SelectCharacter,
                CharacterID.YellowPlayer
            );
            View.BindEvent(DeckBuildScene.Buttons.CoreSlot_Button_3,View.SetCoreExplainText,
                3
            );
            View.BindEvent(DeckBuildScene.Buttons.CoreSlot_Button_3,SelectCharacter,
                CharacterID.WhitePlayer
            );
            View.BindEvent(DeckBuildScene.Buttons.CoreSlot_Button_4,View.SetCoreExplainText,
                4
            );
            View.BindEvent(DeckBuildScene.Buttons.CoreSlot_Button_4,SelectCharacter,
                CharacterID.RedPlayer
            );
            #endregion
            
            #region CombatSkillButtons
            //button 1
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button1,View.BindOnClick,
                DeckBuildScene.Buttons.SkillSlot_Button1
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button1,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SkillSlot_Button1,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button1,View.OnClickedSkillButton,
                "RapidFire",DeckBuildScene.Buttons.SkillSlot_Button1
            );
            //button 2
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button2,View.BindOnClick,
                DeckBuildScene.Buttons.SkillSlot_Button2
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button2,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SkillSlot_Button2,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button2,View.OnClickedSkillButton,
                "Empattack",DeckBuildScene.Buttons.SkillSlot_Button2
            );            
            //button 3
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button3,View.BindOnClick,
                DeckBuildScene.Buttons.SkillSlot_Button3
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button3,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SkillSlot_Button3,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button3,View.OnClickedSkillButton,
                "SateliteBeam",DeckBuildScene.Buttons.SkillSlot_Button3
            );           
            //button 4
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button4,View.BindOnClick,
                DeckBuildScene.Buttons.SkillSlot_Button4
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button4,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SkillSlot_Button4,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button4,View.OnClickedSkillButton,
                "MultipleShot",DeckBuildScene.Buttons.SkillSlot_Button4
            );            
            //button 5
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button5,View.BindOnClick,
                DeckBuildScene.Buttons.SkillSlot_Button5
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button5,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SkillSlot_Button5,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button5,View.OnClickedSkillButton,
                "BigShot",DeckBuildScene.Buttons.SkillSlot_Button5
            );            
            //button 1
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button6,View.BindOnClick,
                DeckBuildScene.Buttons.SkillSlot_Button6
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button6,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SkillSlot_Button6,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button6,View.OnClickedSkillButton,
                "BrandishingGunFire",DeckBuildScene.Buttons.SkillSlot_Button6
            );            
            //button 1
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button7,View.BindOnClick,
                DeckBuildScene.Buttons.SkillSlot_Button7
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button7,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SkillSlot_Button7,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button7,View.OnClickedSkillButton,
                "CoreBeam",DeckBuildScene.Buttons.SkillSlot_Button7
            );            
            //button 1
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button8,View.BindOnClick,
                DeckBuildScene.Buttons.SkillSlot_Button8
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button8,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SkillSlot_Button8,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button8,View.OnClickedSkillButton,
                "GroundScatter",DeckBuildScene.Buttons.SkillSlot_Button8
            );            
            //button 1
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button9,View.BindOnClick,
                DeckBuildScene.Buttons.SkillSlot_Button9
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button9,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SkillSlot_Button9,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button9,View.OnClickedSkillButton,
                "IceFatalWheel",DeckBuildScene.Buttons.SkillSlot_Button9
            );            
            //button 1
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button10,View.BindOnClick,
                DeckBuildScene.Buttons.SkillSlot_Button10
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button10,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SkillSlot_Button10,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button10,View.OnClickedSkillButton,
                "LumenJudgement",DeckBuildScene.Buttons.SkillSlot_Button10
            );            
            //button 1
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button11,View.BindOnClick,
                DeckBuildScene.Buttons.SkillSlot_Button11
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button11,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SkillSlot_Button11,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button11,View.OnClickedSkillButton,
                "IceRing",DeckBuildScene.Buttons.SkillSlot_Button11
            );            
            //button 1
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button12,View.BindOnClick,
                DeckBuildScene.Buttons.SkillSlot_Button12
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button12,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SkillSlot_Button12,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button12,View.OnClickedSkillButton,
                "FloatingWindStorm",DeckBuildScene.Buttons.SkillSlot_Button12
            );            
            //button 1
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button13,View.BindOnClick,
                DeckBuildScene.Buttons.SkillSlot_Button13
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button13,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SkillSlot_Button13,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button13,View.OnClickedSkillButton,
                "LightingStrike",DeckBuildScene.Buttons.SkillSlot_Button13
            );            
            //button 1
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button14,View.BindOnClick,
                DeckBuildScene.Buttons.SkillSlot_Button14
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button14,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SkillSlot_Button14,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SkillSlot_Button14,View.OnClickedSkillButton,
                "SprialWheels",DeckBuildScene.Buttons.SkillSlot_Button14
            );   
            
            
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_0,View.BindOnClickNoInvoke,
                DeckBuildScene.Buttons.Content_Equip_Skill_0
            );
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_0,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.Content_Equip_Skill_0,View.SlotButtons
            );
            // View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_0,View.OnSelectedSlot,
            //     DeckBuildScene.Buttons.Content_Equip_Skill_0
            // );
            
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_1,View.BindOnClickNoInvoke,
                DeckBuildScene.Buttons.Content_Equip_Skill_1
            );
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_1,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.Content_Equip_Skill_1,View.SlotButtons
            );            
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_1,View.OnSelectedSlot,
                DeckBuildScene.Buttons.Content_Equip_Skill_1
            );
            
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_2,View.BindOnClickNoInvoke,
                DeckBuildScene.Buttons.Content_Equip_Skill_2
            );
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_2,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.Content_Equip_Skill_2,View.SlotButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_2,View.OnSelectedSlot,
                DeckBuildScene.Buttons.Content_Equip_Skill_2
            );
            
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_3,View.BindOnClickNoInvoke,
                DeckBuildScene.Buttons.Content_Equip_Skill_3
            );
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_3,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.Content_Equip_Skill_3,View.SlotButtons
            ); 
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_3,View.OnSelectedSlot,
                DeckBuildScene.Buttons.Content_Equip_Skill_3
            );
            
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_4,View.BindOnClickNoInvoke,
                DeckBuildScene.Buttons.Content_Equip_Skill_4
            );
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_4,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.Content_Equip_Skill_4,View.SlotButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_4,View.OnSelectedSlot,
                DeckBuildScene.Buttons.Content_Equip_Skill_4
            );
            
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_5,View.BindOnClickNoInvoke,
                DeckBuildScene.Buttons.Content_Equip_Skill_5
            );
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_5,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.Content_Equip_Skill_5,View.SlotButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.Content_Equip_Skill_5,View.OnSelectedSupSlot,
                DeckBuildScene.Buttons.Content_Equip_Skill_5
            );
            
            #endregion

            #region SupportSkillButtons
    
            //button1
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button1,View.BindOnClick,
                DeckBuildScene.Buttons.SupSkillSlot_Button1
            );
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button1,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SupSkillSlot_Button1,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button1,View.OnClickedSupSkillButton,
                "Overload",DeckBuildScene.Buttons.SupSkillSlot_Button1
            );
            //button1
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button2,View.BindOnClick,
                DeckBuildScene.Buttons.SupSkillSlot_Button2
            );
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button2,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SupSkillSlot_Button2,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button2,View.OnClickedSupSkillButton,
                "UnderVolting",DeckBuildScene.Buttons.SupSkillSlot_Button2
            );
            //button1
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button3,View.BindOnClick,
                DeckBuildScene.Buttons.SupSkillSlot_Button3
            );
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button3,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SupSkillSlot_Button3,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button3,View.OnClickedSupSkillButton,
                "MultiThreading",DeckBuildScene.Buttons.SupSkillSlot_Button3
            );
            //button1
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button4,View.BindOnClick,
                DeckBuildScene.Buttons.SupSkillSlot_Button4
            );
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button4,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SupSkillSlot_Button4,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button4,View.OnClickedSupSkillButton,
                "GateofTruth",DeckBuildScene.Buttons.SupSkillSlot_Button4
            );
            //button1
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button5,View.BindOnClick,
                DeckBuildScene.Buttons.SupSkillSlot_Button5
            );
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button5,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SupSkillSlot_Button5,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button5,View.OnClickedSupSkillButton,
                "EvilContract",DeckBuildScene.Buttons.SupSkillSlot_Button5
            );
            //button1
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button6,View.BindOnClick,
                DeckBuildScene.Buttons.SupSkillSlot_Button6
            );
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button6,View.DisableButtonWithOutMe,
                DeckBuildScene.Buttons.SupSkillSlot_Button6,View.CombatButtons
            );
            View.BindEvent(DeckBuildScene.Buttons.SupSkillSlot_Button6,View.OnClickedSupSkillButton,
                "HolyContract",DeckBuildScene.Buttons.SupSkillSlot_Button6
            );

            #endregion
            
            //Exit_Button
            View.BindEvent(DeckBuildScene.Buttons.Exit_Button,GotoDeckBuildRoom
            );
        }
        public void GotoDeckBuildRoom()
        {
            MoveScene(_LobbyScene);
        }   
        public void SelectCharacter(CharacterID id)
        {
            if (Playerdatamanager == null)
            {
                Debug.Log("Player Data Manager Missing!");
                return;
            }

            Playerdatamanager.SelectCharacter(id);
        }
        public void SelectCoreSkill(int CoreNumber,string value)
        {
            if (Playerdatamanager == null)
            {
                Debug.Log("Player Data Manager Missing!");
                return;
            }
            Playerdatamanager.SelectSkillInSlot(CoreNumber,value);
        }

        public void SaveData()
        {
            SettingMyEnterData();
            Playerdatamanager.SAVEMY();
        }
        public void ResetSetting()
        {
            SettingMySet();   
        }
        public void SettingMySet()
        {
            
            View.CleanSlot();
            
            //Debug.Log($"slot1 : {slot1}");
            //Debug.Log($"slot2 : {slot2}");
            //Debug.Log($"slot3 : {slot3}");
            //Debug.Log($"slot4 : {slot4}");
            //Debug.Log($"slot5 : {slot5}");
            
            switch (charid)
            {
                case CharacterID.BlackPlayer:
                    View.GetButton(DeckBuildScene.Buttons.CoreSlot_Button_1).Button_.onClick?.Invoke();
                    break;
                case CharacterID.YellowPlayer:
                    View.GetButton(DeckBuildScene.Buttons.CoreSlot_Button_2).Button_.onClick?.Invoke();
                    break;
                case CharacterID.WhitePlayer:
                    View.GetButton(DeckBuildScene.Buttons.CoreSlot_Button_2).Button_.onClick?.Invoke();
                    break;
                case CharacterID.RedPlayer:
                    View.GetButton(DeckBuildScene.Buttons.CoreSlot_Button_2).Button_.onClick?.Invoke();
                    break;
                
            }
            //sodata.Slot1Data
            Skills skill1 = (Skills)Enum.Parse(typeof(Skills), slot1);
            switch (skill1)
            {
                case Skills.RapidFire:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button1).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_1).Button_.onClick?.Invoke();
                    break;
                case Skills.Empattack:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button2).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_1).Button_.onClick?.Invoke();
                    break;
                case Skills.SateliteBeam:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button3).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_1).Button_.onClick?.Invoke();
                    break;
                case Skills.MultipleShot:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button4).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_1).Button_.onClick?.Invoke();
                    break;
                case Skills.BigShot:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button5).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_1).Button_.onClick?.Invoke();
                    break;
                case Skills.BrandishingGunFire:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button6).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_1).Button_.onClick?.Invoke();
                    break;
                case Skills.CoreBeam:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button7).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_1).Button_.onClick?.Invoke();
                    break;
                case Skills.GroundScatter:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button8).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_1).Button_.onClick?.Invoke();
                    break;
                case Skills.IceFatalWheel:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button9).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_1).Button_.onClick?.Invoke();
                    break;
                case Skills.LumenJudgement:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button10).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_1).Button_.onClick?.Invoke();
                    break;
                case Skills.IceRing:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button11).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_1).Button_.onClick?.Invoke();
                    break;
                case Skills.FloatingWindStorm:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button12).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_1).Button_.onClick?.Invoke();
                    break;
                case Skills.LightingStrike:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button13).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_1).Button_.onClick?.Invoke();
                    break;
                case Skills.SprialWheels:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button14).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_1).Button_.onClick?.Invoke();
                    break;
            }
            //sodata.Slot1Data
            Skills skill2 = (Skills)Enum.Parse(typeof(Skills), slot2);
            switch (skill2)
            {
               case Skills.RapidFire:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button1).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_2).Button_.onClick?.Invoke();
                    break;
                case Skills.Empattack:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button2).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_2).Button_.onClick?.Invoke();
                    break;
                case Skills.SateliteBeam:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button3).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_2).Button_.onClick?.Invoke();
                    break;
                case Skills.MultipleShot:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button4).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_2).Button_.onClick?.Invoke();
                    break;
                case Skills.BigShot:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button5).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_2).Button_.onClick?.Invoke();
                    break;
                case Skills.BrandishingGunFire:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button6).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_2).Button_.onClick?.Invoke();
                    break;
                case Skills.CoreBeam:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button7).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_2).Button_.onClick?.Invoke();
                    break;
                case Skills.GroundScatter:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button8).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_2).Button_.onClick?.Invoke();
                    break;
                case Skills.IceFatalWheel:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button9).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_2).Button_.onClick?.Invoke();
                    break;
                case Skills.LumenJudgement:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button10).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_2).Button_.onClick?.Invoke();
                    break;
                case Skills.IceRing:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button11).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_2).Button_.onClick?.Invoke();
                    break;
                case Skills.FloatingWindStorm:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button12).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_2).Button_.onClick?.Invoke();
                    break;
                case Skills.LightingStrike:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button13).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_2).Button_.onClick?.Invoke();
                    break;
                case Skills.SprialWheels:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button14).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_2).Button_.onClick?.Invoke();
                    break;
            }
            //sodata.Slot1Data
            Skills skill3 = (Skills)Enum.Parse(typeof(Skills), slot3);
            switch (skill3)
            {
                case Skills.RapidFire:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button1).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_3).Button_.onClick?.Invoke();
                    break;
                case Skills.Empattack:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button2).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_3).Button_.onClick?.Invoke();
                    break;
                case Skills.SateliteBeam:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button3).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_3).Button_.onClick?.Invoke();
                    break;
                case Skills.MultipleShot:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button4).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_3).Button_.onClick?.Invoke();
                    break;
                case Skills.BigShot:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button5).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_3).Button_.onClick?.Invoke();
                    break;
                case Skills.BrandishingGunFire:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button6).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_3).Button_.onClick?.Invoke();
                    break;
                case Skills.CoreBeam:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button7).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_3).Button_.onClick?.Invoke();
                    break;
                case Skills.GroundScatter:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button8).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_3).Button_.onClick?.Invoke();
                    break;
                case Skills.IceFatalWheel:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button9).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_3).Button_.onClick?.Invoke();
                    break;
                case Skills.LumenJudgement:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button10).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_3).Button_.onClick?.Invoke();
                    break;
                case Skills.IceRing:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button11).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_3).Button_.onClick?.Invoke();
                    break;
                case Skills.FloatingWindStorm:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button12).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_3).Button_.onClick?.Invoke();
                    break;
                case Skills.LightingStrike:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button13).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_3).Button_.onClick?.Invoke();
                    break;
                case Skills.SprialWheels:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button14).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_3).Button_.onClick?.Invoke();
                    break;
            }
            //sodata.Slot1Data
            Skills skill4 = (Skills)Enum.Parse(typeof(Skills), slot4);
            switch (skill4)
            {
                case Skills.RapidFire:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button1).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_4).Button_.onClick?.Invoke();
                    break;
                case Skills.Empattack:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button2).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_4).Button_.onClick?.Invoke();
                    break;
                case Skills.SateliteBeam:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button3).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_4).Button_.onClick?.Invoke();
                    break;
                case Skills.MultipleShot:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button4).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_4).Button_.onClick?.Invoke();
                    break;
                case Skills.BigShot:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button5).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_4).Button_.onClick?.Invoke();
                    break;
                case Skills.BrandishingGunFire:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button6).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_4).Button_.onClick?.Invoke();
                    break;
                case Skills.CoreBeam:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button7).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_4).Button_.onClick?.Invoke();
                    break;
                case Skills.GroundScatter:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button8).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_4).Button_.onClick?.Invoke();
                    break;
                case Skills.IceFatalWheel:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button9).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_4).Button_.onClick?.Invoke();
                    break;
                case Skills.LumenJudgement:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button10).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_4).Button_.onClick?.Invoke();
                    break;
                case Skills.IceRing:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button11).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_4).Button_.onClick?.Invoke();
                    break;
                case Skills.FloatingWindStorm:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button12).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_4).Button_.onClick?.Invoke();
                    break;
                case Skills.LightingStrike:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button13).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_4).Button_.onClick?.Invoke();
                    break;
                case Skills.SprialWheels:
                    View.GetButton(DeckBuildScene.Buttons.SkillSlot_Button14).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_4).Button_.onClick?.Invoke();
                    break;
            }
            SupSkills supskill = (SupSkills)Enum.Parse(typeof(SupSkills), slot5);
            switch (supskill)
            {
                case SupSkills.Overload:
                    View.GetButton(DeckBuildScene.Buttons.SupSkillSlot_Button1).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_5).Button_.onClick?.Invoke();
                    break;
                case SupSkills.UnderVolting:
                    View.GetButton(DeckBuildScene.Buttons.SupSkillSlot_Button2).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_5).Button_.onClick?.Invoke();
                    break;
                case SupSkills.MultiThreading:
                    View.GetButton(DeckBuildScene.Buttons.SupSkillSlot_Button3).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_5).Button_.onClick?.Invoke();
                    break;
                case SupSkills.GateofTruth:
                    View.GetButton(DeckBuildScene.Buttons.SupSkillSlot_Button4).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_5).Button_.onClick?.Invoke();
                    break;
                case SupSkills.EvilContract:
                    View.GetButton(DeckBuildScene.Buttons.SupSkillSlot_Button5).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_5).Button_.onClick?.Invoke();
                    break;
                case SupSkills.HolyContract:
                    View.GetButton(DeckBuildScene.Buttons.SupSkillSlot_Button6).Button_.onClick?.Invoke();
                    View.GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_5).Button_.onClick?.Invoke();
                    break;
                default:
                    break;
            }

        }
    }
}
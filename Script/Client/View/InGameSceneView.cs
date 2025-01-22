using System;
using Google.Protobuf.Protocol;
using Script.Client.Manager;
using Script.Client.Manager.SceneManager;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Client.View
{
    public class InGameSceneView : MonoBehaviour
    {
        public static InGameSceneView instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public static string SlotImagePath = "SlotImage/";
        public static string CharImagePath = "IconImage/";
        public static string SlotNullImage = "deckinfo_slot_s";
        public static string SlotBasicImage = "icon_deckinfo_Core_1";
        
        public Slider MyHpSlider;
        public Image QSkillIcon;
        public Image WSkillIcon;
        public Image ESkillIcon;
        public Image RSkillIcon;
        public Image TSkillIcon;

        public Image MyCharIcon;
        public Image EnemyCharIcon;
        
        
        public Text MyPlayerName;
        public Text EnemyPlayerName;

        public float CurrentHP;
        public float MaxHP;
        
        void Start()
        {
            MyHpSlider.value = 1;
        }
        
        public void ChangePlayerName(string me)
        {
            MyPlayerName.text = me;
        }

        public void ChangeEnemyName(string enemy)
        {
            EnemyPlayerName.text = enemy;
        }

        public void ChangeMyIcon(CharacterID id)
        {
            string basepath = InGameSceneManager.instance.GetCoreIConPath((int)id);
            
            Sprite textAsset = Resources.Load<Sprite>(CharImagePath+basepath);
            MyCharIcon.sprite = textAsset;

        }

        public void ChangeEnemyIcon(CharacterID id)
        {
            string basepath = InGameSceneManager.instance.GetCoreIConPath((int)id);
            
            Sprite textAsset = Resources.Load<Sprite>(CharImagePath+basepath); 
                EnemyCharIcon.sprite = textAsset;
            
        }

        public void ChangeSKilQ(string skillcode)
        {
            Skills code = (Skills)Enum.Parse(typeof(Skills), skillcode);
            string basepath = InGameSceneManager.instance.GetSkillPath(code);
            
            Sprite textAsset = Resources.Load<Sprite>(SlotImagePath+basepath);
            QSkillIcon.sprite = textAsset;
        }

        public Text Qcool;
        public void UpdateQCoolTime(string value)
        {
            Qcool.text = value;
        }
        
        public void ChangeSKilW(string skillcode)
        {    
            Skills code = (Skills)Enum.Parse(typeof(Skills), skillcode);
            string basepath = InGameSceneManager.instance.GetSkillPath(code);
            
            Sprite textAsset = Resources.Load<Sprite>(SlotImagePath+basepath);
            WSkillIcon.sprite = textAsset;
        }
        public Text Wcool;
        public void UpdateWCoolTime(string value)
        {
            Wcool.text = value;
        }
        public void ChangeSKilE(string skillcode)
        {
            Skills code = (Skills)Enum.Parse(typeof(Skills), skillcode);
            string basepath = InGameSceneManager.instance.GetSkillPath(code);
            
            Sprite textAsset = Resources.Load<Sprite>(SlotImagePath+basepath);
            ESkillIcon.sprite = textAsset;
        }
        public Text Ecool;
        public void UpdateECoolTime(string value)
        {
            Ecool.text = value;
        }

       
        public void ChangeSKilR(string skillcode)
        {
            Skills code = (Skills)Enum.Parse(typeof(Skills), skillcode);
            string basepath = InGameSceneManager.instance.GetSkillPath(code);
            
            Sprite textAsset = Resources.Load<Sprite>(SlotImagePath+basepath);
            RSkillIcon.sprite = textAsset;
        }
        public Text Rcool;
        public void UpdateRCoolTime(string value)
        {
            Rcool.text = value;
        }
        public void ChangeSKilT(string skillcode)
        {
            //Skills code = (Skills)Enum.Parse(typeof(Skills), skillcode);
            //string basepath = InGameSceneManager.instance.GetSkillPath(code);
            
            //Sprite textAsset = Resources.Load<Sprite>(SlotImagePath+basepath);
            //TSkillIcon.sprite = textAsset;
        }

        public void ClearQCoolTime()
        {
            Qcool.text = "";
        }
        public void ClearWCoolTime()
        {
            Wcool.text = "";
        }
        public void ClearECoolTime()
        {
            Ecool.text = "";
        }
        public void ClearRCoolTime()
        {
            Rcool.text = "";
        }
        
        public void OnHpChanged(float curhp)
        {
            float dmg = CurrentHP - curhp;
            CurrentHP = dmg;
            MyHpSlider.value = dmg/MaxHP;
        }

        
    }
}
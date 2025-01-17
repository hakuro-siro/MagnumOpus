using UnityEngine;
using Script.Client.Scene;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Script.Client.UI;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Script.Client.Manager.SceneManager;
using Script.Client.UI.DeckBuildScene;
using Image = UnityEngine.UIElements.Image;


/// <summary>
/// UniRX MVP View
/// </summary>
public class DeckBuildSceneView : MonoBehaviour
{
    public DeckBuildSceneManager manager;
    
    private event Action OnReleasedButton;
    private event Action<DeckBuildScene.Buttons> OnClickSlotButton;
    private event Action<DeckBuildScene.Buttons> OnClickSupButton;

    private const int BLACK = 1;
    private const int YELLOW = 2;
    private const int WHITE = 3;
    private const int RED = 4;
            

    
    [Header("Character Field")] 
    public GameObject BLACKobj;
    public GameObject YELLOWobj;
    public GameObject WHITEobj;
    public GameObject REDobj;
        
    
    
    public UI_Button_DeckBuildScene Buttons;
    public UI_Panel_DeckBuildScene Pannels;
    public UI_Text_DeckBuildScene Texts;
    public UI_Image_DeckBuildScene Images;
    
    public List<int> MenuButtons;
    public List<int> CoreButtons;
    public List<int> CombatButtons;
    public List<int> SlotButtons;
    public List<int> SlotImages;

    public List<int> MenuPanels;

    public static string CoreJsonPath = "DeckBuildSceneCore";
    public static string CombatJsonPath = "DeckBuildSceneCombat";
    public static string SupportJsonPath = "DeckBuildSceneSupport";
    
    public static string SlotImagePath = "SlotImage/";
    public static string SlotNullImage = "deckinfo_slot_s";
    public static string SlotBasicImage = "icon_deckinfo_Core_1";

    //BASE
    public Text GetText(DeckBuildScene.Texts value)
    {
        return Texts.Get<Text>((int)value);
    }
    public BasePanel GetPanel(DeckBuildScene.Pannels value)
    {
        return Pannels.Get<BasePanel>((int)value);
    }
    public BaseButton GetButton(DeckBuildScene.Buttons value)
    {
        return Buttons.Get<BaseButton>((int)value);
    }
    public BaseImage GetImage(DeckBuildScene.Images value)
    {
        return Images.Get<BaseImage>((int)value);
    }
    
    /// <summary>
    /// Bind Event
    /// </summary>
    /// <param name="button">Button</param>
    /// <param name="Func">Func</param>
    /// <param name="Value">Value</param>
    public void BindEvent<T>(DeckBuildScene.Buttons button, Action<T> Func, T Value)
    {
        GetButton(button).Button_.onClick.AsObservable().Subscribe(_ => Func(Value));
    }
    public void BindEvent<T,U>(DeckBuildScene.Buttons button, Action<T,U> Func, T Value,U _Value)
    {
        GetButton(button).Button_.onClick.AsObservable().Subscribe(_ => Func(Value,_Value));
    }
    public void BindEvent(DeckBuildScene.Buttons button, Action Func)
    {
        GetButton(button).Button_.onClick.AsObservable().Subscribe(_ => Func());
    }
    public void Packing<T>(List<T> TypeList, T value)
    {
        TypeList.Add(value);
    }
    
    public void DisableButtonWithOutMe(DeckBuildScene.Buttons button, List<int> list)
    {
        foreach (var VAR in list)
        {
            if(VAR != (int)button)
                DisableButton((DeckBuildScene.Buttons)VAR);
        }
    }

    public void DisableButton(DeckBuildScene.Buttons button)
    {
        GetButton(button).IsClicked = false;
        GetButton(button).OnClicked.SetActive(GetButton(button).IsClicked);
    }
    public void BindOnClick(DeckBuildScene.Buttons button)
    {
        OnReleasedButton?.Invoke();
        DisableButton(CurrentSkillButton);
        GetButton(button).IsClicked = true;
        GetButton(button).OnClicked.SetActive(GetButton(button).IsClicked);
    }
    public void BindOnClickNoInvoke(DeckBuildScene.Buttons button)
    {
        GetButton(button).IsClicked = true;
        GetButton(button).OnClicked.SetActive(GetButton(button).IsClicked);
    }
    
    public void OpenPanel(DeckBuildScene.Pannels panel)
    {
        GetPanel(panel).OpenThisPanel();
    }
    public void ClosePanel(DeckBuildScene.Pannels panel)
    {
        GetPanel(panel).CloseThisPanel();
    }
    public void CloseMainPanelWithOutMe(DeckBuildScene.Pannels panel)
    {
        foreach (var VAR in MenuPanels)
        {
            if(VAR != (int)panel)
                ClosePanel((DeckBuildScene.Pannels)VAR);
        }
    }


    public void SetText(DeckBuildScene.Texts Text, string Value)
    {
        GetText(Text).text = Value;
    }
//ENDBASE
    public TextAsset LoadTextPack(string path)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        //string Text = JsonUtility.FromJson<string>(textAsset.text);
        return textAsset;
    }

    public CombatSkillData GetCombatSkillData(string skillCode)
    {      
        CombatData data = JsonUtility.FromJson<CombatData>(LoadTextPack(CombatJsonPath).ToString());

        foreach (var var in data.CombatSkills)
        {
            if (skillCode.ToString() == var.SkillCode.ToString())
            {
                // Skill_ExplainTitle,
                // CombatExplainMainText,
                // SubTitleMark,
                // CombatExplainSubText_1
                SetText(DeckBuildScene.Texts.Skill_ExplainTitle,var.SkillTitle);
                SetText(DeckBuildScene.Texts.CombatExplainMainText,var.SkillExplain);
                SetText(DeckBuildScene.Texts.ExplainsubTitle,var.SkillSubTitle);
                SetText(DeckBuildScene.Texts.CombatExplainSubText_1,var.SkillSubExplain);

                return var;
            }
        }
        Debug.LogError("Cannot Found SkillData!");
        return null;
    }
    public SupportSkillData GetSupportSkillData(string skillCode)
    {      
        SupportData data = JsonUtility.FromJson<SupportData>(LoadTextPack(SupportJsonPath).ToString());

        foreach (var var in data.SupportSkills)
        {
            if (skillCode.ToString() == var.SkillCode.ToString())
            {
                // Supskill_ExplainTitle,
                // SupSkillExplainMainText,
                // SupskillExplainsubTitle,
                // SupSkillExplainSubText_1
                SetText(DeckBuildScene.Texts.SupSkill_ExplainTitle,var.SkillTitle);
                SetText(DeckBuildScene.Texts.SupSkillExplainMainText,var.SkillExplain);
                SetText(DeckBuildScene.Texts.SupSkillExplainsubTitle,var.SkillSubTitle);
                SetText(DeckBuildScene.Texts.SupSkillExplainSubText_1,var.SkillSubExplain);

                return var;
            }
        }
        Debug.LogError("Cannot Found SUP - SkillData!");
        return null;
    }
//IF slect CORE Button
    public void SetCoreExplainText(int ID)
    {
        SetCoreExplainMain(ID);
        switch (ID)
        {
            case BLACK:
                BLACKobj.SetActive(true);
                YELLOWobj.SetActive(false);
                WHITEobj.SetActive(false);
                REDobj.SetActive(false);
                break;
            case YELLOW:
                BLACKobj.SetActive(false);
                YELLOWobj.SetActive(true);
                WHITEobj.SetActive(false);
                REDobj.SetActive(false);
                break;
            case WHITE:
                BLACKobj.SetActive(false);
                YELLOWobj.SetActive(false);
                WHITEobj.SetActive(true);
                REDobj.SetActive(false);
                break;
            case RED:
                BLACKobj.SetActive(false);
                YELLOWobj.SetActive(false);
                WHITEobj.SetActive(false);
                REDobj.SetActive(true);
                break;
        }
    }
    
    public void SetCoreExplainMain(int ID)
    {
        CoreData data = JsonUtility.FromJson<CoreData>(LoadTextPack(CoreJsonPath).ToString());
        //Debug.Log(data.Cores.Count);
        foreach (var var in data.Cores)
        {
            if (ID.ToString() == var.CoreID.ToString())
            {
                SetText(DeckBuildScene.Texts.Core_ExplainTitle,var.CoreName);
                SetText(DeckBuildScene.Texts.ExplainTitle_sub,var.CoreNameSub);
                SetText(DeckBuildScene.Texts.CoreExplainMainText,var.CoreNameExplain);
                SetText(DeckBuildScene.Texts.CoreExplainSubText_1,var.ExplainText_1);
                SetText(DeckBuildScene.Texts.CoreExplainSubText_2,var.ExplainText_2);

            }
        }

        OnSelectedSlotWithCore(ID);
    }  
    public CoreTextData GetCoreData(int ID)
    {
        CoreData data = JsonUtility.FromJson<CoreData>(LoadTextPack(CoreJsonPath).ToString());
        //Debug.Log(data.Cores.Count);
        foreach (var var in data.Cores)
        {
            if (ID.ToString() == var.CoreID.ToString())
            {
                return var;
            }
        }
        return null;
    } 
//ENDIF

//IF slect CombatSkill Button
    private string CurrentSkillCode;
    private DeckBuildScene.Buttons CurrentSkillButton;
    public void OnClickedSkillButton(string skillCode,DeckBuildScene.Buttons value)
    {
        GetCombatSkillData(skillCode);
        CurrentSkillCode = skillCode;
        CurrentSkillButton = value;
        OnReleasedButton += KillCombatCoru;
        OnClickSlotButton += OnSelectedSlotWithSkill;
    }

    public void KillCombatCoru()
    {
        CurrentSkillCode = "NULL";
        OnReleasedButton -= KillCombatCoru;
        OnClickSlotButton -= OnSelectedSlotWithSkill;
    }

//ENDIF

//IF slect SupportSkill Button

    public void OnClickedSupSkillButton(string skillCode,DeckBuildScene.Buttons value)
    {
        GetSupportSkillData(skillCode);
        CurrentSkillCode = skillCode;
        CurrentSkillButton = value;
        OnReleasedButton += KillSupCoru;
        OnClickSupButton += OnSelectedSlotWithSup;
    }
    public void KillSupCoru()
    {
        CurrentSkillCode = "NULL";
        OnReleasedButton -= KillCombatCoru;
        OnClickSupButton -= OnSelectedSlotWithSup;
    }
    // On Select Support core with slot
    
    //Call this Method on clicked support skill
    public void SetSupportExplainMain(int skillcode)
    {
        SupportData data = JsonUtility.FromJson<SupportData>(LoadTextPack(CoreJsonPath).ToString());
        //Debug.Log(data.Cores.Count);
        foreach (var var in data.SupportSkills)
        {
            if (skillcode.ToString() == var.SkillCode.ToString())
            {
                SetText(DeckBuildScene.Texts.SupSkill_ExplainTitle,var.SkillTitle);
                SetText(DeckBuildScene.Texts.SupSkillExplainMainText,var.SkillExplain);
                SetText(DeckBuildScene.Texts.SupSkillExplainsubTitle,var.SkillSubTitle);
                SetText(DeckBuildScene.Texts.SupSkillExplainSubText_1,var.SkillSubExplain);
            }
        }

        
    }  
    
    public void OnSelectedSlotWithSupport(string skillcode)
    {
        Sprite textAsset = Resources.Load<Sprite>(SlotImagePath+SlotBasicImage);
        GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_5).OnCommonText.text = GetSupportSkillData(skillcode.ToString()).SkillTitle;
        GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_5).OnClickedText.text= GetSupportSkillData(skillcode.ToString()).SkillTitle;
        GetImage(DeckBuildScene.Images.Content_Equip_Skill_5).ChangeImage_Onclick(textAsset);
        GetImage(DeckBuildScene.Images.Content_Equip_Skill_5).ChangeImage(textAsset);
    }








//ENDIF

//IF slect Slot Button
    public void OnSelectedSlot(DeckBuildScene.Buttons value)
    { 
        OnClickSlotButton?.Invoke(value);
    }
    public void OnSelectedSupSlot(DeckBuildScene.Buttons value)
    { 
        OnClickSupButton?.Invoke(value);
    }
    //value = slotbutton
    public void OnSelectedSlotWithSkill(DeckBuildScene.Buttons value)
    {
        Debug.Log($"slot {value} in {CurrentSkillCode}");
        DisableButton(CurrentSkillButton);
        Sprite textAsset = Resources.Load<Sprite>(SlotImagePath+GetCombatSkillData(CurrentSkillCode).ImageID);

        switch (value)
        {
            case DeckBuildScene.Buttons.Content_Equip_Skill_1 :
                GetImage(DeckBuildScene.Images.Content_Equip_Skill_1).ChangeImage_Onclick(textAsset);
                GetImage(DeckBuildScene.Images.Content_Equip_Skill_1).ChangeImage(textAsset);
                manager.SelectCoreSkill(1,GetCombatSkillData(CurrentSkillCode).SkillCode); break;
            case DeckBuildScene.Buttons.Content_Equip_Skill_2 :
                GetImage(DeckBuildScene.Images.Content_Equip_Skill_2).ChangeImage_Onclick(textAsset);
                GetImage(DeckBuildScene.Images.Content_Equip_Skill_2).ChangeImage(textAsset);
                manager.SelectCoreSkill(2,GetCombatSkillData(CurrentSkillCode).SkillCode); break;      
            case DeckBuildScene.Buttons.Content_Equip_Skill_3 :
                GetImage(DeckBuildScene.Images.Content_Equip_Skill_3).ChangeImage_Onclick(textAsset);
                GetImage(DeckBuildScene.Images.Content_Equip_Skill_3).ChangeImage(textAsset);
                manager.SelectCoreSkill(3,GetCombatSkillData(CurrentSkillCode).SkillCode);  break;     
            case DeckBuildScene.Buttons.Content_Equip_Skill_4 :
                GetImage(DeckBuildScene.Images.Content_Equip_Skill_4).ChangeImage_Onclick(textAsset);
                GetImage(DeckBuildScene.Images.Content_Equip_Skill_4).ChangeImage(textAsset);
                manager.SelectCoreSkill(4,GetCombatSkillData(CurrentSkillCode).SkillCode);  break;     
        }

        GetButton(value).OnCommonText.text = GetCombatSkillData(CurrentSkillCode).SkillTitle;
        GetButton(value).OnClickedText.text= GetCombatSkillData(CurrentSkillCode).SkillTitle;
       OnReleasedButton?.Invoke();
    }
    // on click slot 6
    public void OnSelectedSlotWithSup(DeckBuildScene.Buttons value)
    {    
        switch (value)
        {
            case DeckBuildScene.Buttons.Content_Equip_Skill_1 : return;
               break;
            case DeckBuildScene.Buttons.Content_Equip_Skill_2 :  return;
                break;      
            case DeckBuildScene.Buttons.Content_Equip_Skill_3 :  return;
                break;     
            case DeckBuildScene.Buttons.Content_Equip_Skill_4 :  return;
                break;     
        }
        Debug.Log($"sup skill slot in {CurrentSkillCode}");
        DisableButton(CurrentSkillButton);
        OnSelectedSlotWithSupport(CurrentSkillCode);
        manager.SelectCoreSkill(5,GetSupportSkillData(CurrentSkillCode).SkillCode);
        OnReleasedButton?.Invoke();
    }
        
    public void OnSelectedSlotWithCore(int ID)
    {
        Sprite textAsset = Resources.Load<Sprite>(SlotImagePath+SlotBasicImage);
        GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_0).OnCommonText.text = GetCoreData(ID).CoreName;
        GetButton(DeckBuildScene.Buttons.Content_Equip_Skill_0).OnClickedText.text= GetCoreData(ID).CoreName;
        GetImage(DeckBuildScene.Images.Content_Equip_Skill_0).ChangeImage_Onclick(textAsset);
        GetImage(DeckBuildScene.Images.Content_Equip_Skill_0).ChangeImage(textAsset);
    }
    
    public void OnSelectedSlotWithSupport(DeckBuildScene.Buttons value)
    {
        Sprite textAsset = Resources.Load<Sprite>(SlotImagePath+SlotBasicImage);
        GetImage(DeckBuildScene.Images.Content_Equip_Skill_5).ChangeImage_Onclick(textAsset);
        GetImage(DeckBuildScene.Images.Content_Equip_Skill_5).ChangeImage(textAsset);
    }
    
    public void CleanSlot()
    {
        Debug.Log($"path : {SlotImagePath+SlotNullImage}");
        Sprite textAsset = Resources.Load<Sprite>(SlotImagePath+SlotNullImage);
        foreach (var slot in SlotImages)
        {
            GetImage((DeckBuildScene.Images)slot).ChangeImage_Onclick(textAsset);
            GetImage((DeckBuildScene.Images)slot).ChangeImage(textAsset);
        }
    }
//ENDIF


//DATA-SET-FIELD
    [System.Serializable]
    public class CoreData
    {
        public List<CoreTextData> Cores;
    }    
    [System.Serializable]
    public class CombatData
    {
        public List<CombatSkillData> CombatSkills;
    }
    [System.Serializable]
    public class SupportData
    {
        public List<SupportSkillData> SupportSkills;
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
    
    [System.Serializable]
    public class SupportSkillData
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

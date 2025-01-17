using UnityEngine;
using Script.Client.Scene;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Script.Client.UI;
using UniRx;
using System;
using System.Collections.Generic;
using Script.Client.UI.LobbyScene;


/// <summary>
/// UniRX MVP View
/// </summary>
public class LobbySceneView : MonoBehaviour
{
    public UI_Button_LobbyScene Buttons;
    public UI_Panel_LobbyScene Pannels;
    public UI_Text_LobbyScene Texts;
    
    
     public Text GetText(LobbyScene.Texts value)
    {
        return Texts.Get<Text>((int)value);
    }
    public BasePanel GetPanel(LobbyScene.Pannels value)
    {
        return Pannels.Get<BasePanel>((int)value);
    }
    public BaseButton GetButton(LobbyScene.Buttons value)
    {
        return Buttons.Get<BaseButton>((int)value);
    }

    /// <summary>
    /// Bind Event
    /// </summary>
    /// <param name="button">Button</param>
    /// <param name="Func">Func</param>
    /// <param name="Value">Value</param>
    public void BindEvent<T>(LobbyScene.Buttons button, Action<T> Func, T Value)
    {
        GetButton(button).Button_.onClick.AsObservable().Subscribe(_ => Func(Value));
    }
    public void BindEvent<T,U>(LobbyScene.Buttons button, Action<T,U> Func, T Value,U _Value) where T : struct
    {
        GetButton(button).Button_.onClick.AsObservable().Subscribe(_ => Func(Value,_Value));
    }
    public void BindEvent(LobbyScene.Buttons button, Action Func)
    {
        GetButton(button).Button_.onClick.AsObservable().Subscribe(_ => Func());
    }
    public void Packing<T>(List<T> TypeList, T value)
    {
        TypeList.Add(value);
    }
    
    public void DisableButtonWithOutMe(LobbyScene.Buttons button, List<int> list)
    {
        foreach (var VAR in list)
        {
            if(VAR != (int)button)
                DisableButton((LobbyScene.Buttons)VAR);
        }
    }

    public void DisableButton(LobbyScene.Buttons button)
    {
        GetButton(button).IsClicked = false;
        GetButton(button).OnClicked.SetActive(GetButton(button).IsClicked);
    }
    public void BindOnClick(LobbyScene.Buttons button)
    {
        GetButton(button).IsClicked = true;
        GetButton(button).OnClicked.SetActive(GetButton(button).IsClicked);
    }
    
    
    public void OpenPanel(LobbyScene.Pannels panel)
    {
        GetPanel(panel).OpenThisPanel();
    }
    public void ClosePanel(LobbyScene.Pannels panel)
    {
        GetPanel(panel).CloseThisPanel();
    }


    public void SetText(LobbyScene.Texts Text, string Value)
    {
        GetText(Text).text = Value;
    }

}

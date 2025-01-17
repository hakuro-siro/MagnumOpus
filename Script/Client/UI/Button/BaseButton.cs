using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BaseButton : MonoBehaviour
{
    public int ButtonType;
    public bool IsClicked = false;
    public Button Button_;
    public GameObject Common;
    public GameObject OnClicked;

    [Header("Text Field")] 
    public Text OnCommonText; 
    public Text OnClickedText;

    [Header("Hover Color Field")] 
    public Color HoverColor;

    public Color CommonColor;

    public Text HoverText;
    public void OnHovered()
    {
        HoverText.color = HoverColor;
    }

    public void OnCommon()
    {
        HoverText.color = CommonColor;
    }
    
    
    private void Awake()
    {
        Button_ = GetComponent<Button>();
    }
}

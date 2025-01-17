using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BaseImage : MonoBehaviour
{
    public Image MyImage;
    public Image MyImage_OnClick;

    public void ChangeImage(Sprite value)
    {
        MyImage.sprite = value;
    }

    public void ChangeImage_Onclick(Sprite value)
    {
        MyImage_OnClick.sprite = value;
    }
}
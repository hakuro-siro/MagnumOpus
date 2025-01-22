using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static T FindChind<T>(GameObject go, string name = null, bool recursive = false)
    where T : UnityEngine.Object //(�ֻ����θ�, �̸� �Է��ߴ���,����� �˻��� �Ұ�����(�ڽİ˻�))
    {
        if (go == null)
            return null;
        if (recursive == false)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component == null)
                        return component;
                }
            }
        }
        else
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)//�̸��� ����ְų� ���ϴ� �̸��̸� ����
                    return component;
            }
        }
        return null;
    }
}
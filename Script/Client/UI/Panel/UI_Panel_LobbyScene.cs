using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Script.Client.UI.LobbyScene;

namespace Script.Client.UI
{
    public class UI_Panel_LobbyScene : MonoBehaviour
    {
        Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

        private void Awake()
        {
            Bind<BasePanel>(typeof(LobbyScene.LobbyScene.Pannels));
            //Get<Text>((int)Texts.Text).text = "Bind Text"; //���� �κ�
        }

        void Bind<T>(Type type) where T : UnityEngine.Object // UI ���� ���ε�
        {
            String[] names = Enum.GetNames(type);

            UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
            _objects.Add(typeof(T), objects);

            for (int i = 0; i < names.Length; i++)
            {
                objects[i] = Util.FindChind<T>(gameObject, names[i], true);
            }
        }

        internal T Get<T>(int idx) where T : UnityEngine.Object //UI �������� �κ�
        {
            UnityEngine.Object[] objects = null;
            if (_objects.TryGetValue(typeof(T), out objects) == false)
                return null;

            return objects[idx] as T;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Client.UI
{
    public class UI_Image_DeckBuildScene : MonoBehaviour
    {
        Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();
        private void Awake()
        {
            Bind<BaseImage>(typeof(DeckBuildScene.DeckBuildScene.Images));
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
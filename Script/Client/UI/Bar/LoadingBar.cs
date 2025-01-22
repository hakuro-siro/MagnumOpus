using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Client.UI
{
    public class LoadingBar : SliderBar
    {
        public event Action OnLoadBarEnd;

        internal void LoadBarStart(float LoadTime)
        {
            StartCoroutine(LoadWithTimer(LoadTime));
        }

        IEnumerator LoadWithTimer(float time)
        {
            float timer = 0;
            while (true)
            {
                yield return null;
                Sliderbar.value = timer / time;
                if (timer >= time)
                {
                    timer = time;
                    LoadBarEnd();
                    break;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }

        private void LoadBarEnd()
        {
            OnLoadBarEnd?.Invoke();
        }

    }
}
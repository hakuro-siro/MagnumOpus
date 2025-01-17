using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Client.UI
{
    [RequireComponent(typeof(Slider))]
    public class SliderBar : MonoBehaviour
    {
        [SerializeField]
        protected Slider Sliderbar;

        // optional
        [SerializeField]
        protected Text Slidertext;

        [SerializeField]
        protected float MaxValue;
        [SerializeField]
        protected float CurrentValue;

        private void Awake()
        {
            Sliderbar = GetComponent<Slider>();
            Slidertext = GetComponentInChildren<Text>();
        }
        protected virtual void InitbarHandler()
        {

        }
        protected virtual void OnValueChangeHandler(float Value)
        {

        }


    }
}
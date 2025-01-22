using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Script.Client.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class TweenButton : MonoBehaviour
    {
        public RectTransform rectTransform;


        [SerializeField]
        Button button;
        [Header("Button Value Field")]
        [SerializeField]
        private float ButtonValue = 1.15f;
        public bool IsEnable = true;

        [Header("ToggleButton Value")]
        [SerializeField]
        private float TpggleButtonValue = 0.9f;
        [SerializeField]
        private Sprite EnableSprite;
        [SerializeField]
        private Sprite DisableSprite;


        [Header("Common Sprite Movement Value Field")]
        //움직임 강도
        [SerializeField]
        private float Value = 20f;
        //움직임 시간
        [SerializeField]
        private float Time = 0.4f;

        [Header("Option Value Field")]
        //애니메이션 타입
        [SerializeField]
        private AnimationType animtype;
        //자동실행 여부
        [SerializeField]
        private bool ActiveItSelf = true;


        void Awake()
        {
            button = GetComponent<Button>();
            rectTransform = GetComponent<RectTransform>();
        }
        private void Start()
        {
            if (ActiveItSelf)
                PlayAnimation(animtype);
        }

        public void PlayAnimationHandler()
        {
            PlayAnimation(animtype);
        }

        private void PlayAnimation(AnimationType animationType)
        {
            switch (animationType)
            {
                case AnimationType.Button:
                    button.onClick.AddListener(OnButtonClick);
                    break;
                case AnimationType.ToggleButton:
                    IsEnable = true;
                    button.onClick.AddListener(OnTogButtonClick);
                    break;
            }
        }
        void OnButtonClick()
        {
            OnButtonClicked();
            transform.DOScale(ButtonValue, 0.4f).SetEase(Ease.OutElastic).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
            transform.DOScale(1.0f, 0.4f).SetEase(Ease.OutElastic).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
        }
        void OnTogButtonClick()
        {


            if (IsEnable)
            {
                IsEnable = false;
                OnTogButtonDisable();
                button.image.sprite = DisableSprite;
                transform.DOScale(TpggleButtonValue, 0.4f).SetEase(Ease.OutElastic).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
            }
            else
            {
                IsEnable = true;
                OnTogButtonEnable();
                button.image.sprite = EnableSprite;
                transform.DOScale(1.0f, 0.4f).SetEase(Ease.OutElastic).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
            }
        }

        protected virtual void OnButtonClicked()
        {

        }
        protected virtual void OnTogButtonEnable()
        {

        }
        protected virtual void OnTogButtonDisable()
        {

        }

        public enum AnimationType
        {
            Button,
            ToggleButton,
        }
    }
}
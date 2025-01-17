using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

namespace Script.Client.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class TweenPanel : MonoBehaviour
    {
        // Tween 종료 Invoke
        public event Action OnTweenEnd;

        public RectTransform rectTransform;

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
            rectTransform = GetComponent<RectTransform>();
        }
        private void Start()
        {
            if (ActiveItSelf)
                PlayAnimation(animtype);
        }

        /// <summary>
        /// 자동실행일 경우만
        /// </summary>
        public void PlayAnimationHandler()
        {
            PlayAnimation(animtype);
        }

        /// <summary>
        /// 임의의 애니메이션 타입을 통한 Tween 동작
        /// </summary>
        /// <param name="animtype">Tween 애니메이션 종류</param>
        public void PlayAnimationHandler(AnimationType animtype)
        {
            PlayAnimation(animtype);
        }

        private void PlayAnimation(AnimationType animationType)
        {
            switch (animationType)
            {
                case AnimationType.Popup:
                    ShowWindow_Popup();
                    break;
                case AnimationType.ClosePopup:
                    CloseWindow_Popup();
                    break;
                case AnimationType.DownPopup:
                    ShowWindow_DownPopup();
                    break;
            }
        }
        void ShowWindow_Popup()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(1, Time).SetEase(Ease.OutBounce).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
        }
        void CloseWindow_Popup()
        {
            transform.DOScale(0, Time).SetEase(Ease.InOutQuint).SetLink(gameObject, LinkBehaviour.KillOnDestroy).OnComplete(() => { OnTweenEnd?.Invoke(); });
        }

        void ShowWindow_DownPopup()
        {
            rectTransform.DOLocalMoveY(Value, Time).SetEase(Ease.OutBounce).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
        }

        public enum AnimationType
        {
            Popup,
            ClosePopup,
            DownPopup,
            CloseDownPopup
        }
    }
}
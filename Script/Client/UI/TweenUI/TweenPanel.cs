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
        // Tween ���� Invoke
        public event Action OnTweenEnd;

        public RectTransform rectTransform;

        [Header("Common Sprite Movement Value Field")]
        //������ ����
        [SerializeField]
        private float Value = 20f;
        //������ �ð�
        [SerializeField]
        private float Time = 0.4f;

        [Header("Option Value Field")]
        //�ִϸ��̼� Ÿ��
        [SerializeField]
        private AnimationType animtype;
        //�ڵ����� ����
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
        /// �ڵ������� ��츸
        /// </summary>
        public void PlayAnimationHandler()
        {
            PlayAnimation(animtype);
        }

        /// <summary>
        /// ������ �ִϸ��̼� Ÿ���� ���� Tween ����
        /// </summary>
        /// <param name="animtype">Tween �ִϸ��̼� ����</param>
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
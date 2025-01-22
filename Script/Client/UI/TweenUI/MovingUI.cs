using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


namespace Script.Client.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class MovingUI : MonoBehaviour
    {
        public RectTransform rectTransform;

        [Header("IF you use Blink Option...")]
        [SerializeField]
        private Image mysprite;

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

        public void PlayAnimationHandler()
        {
            PlayAnimation(animtype);
        }

        private void PlayAnimation(AnimationType animationType)
        {
            switch (animationType)
            {
                case AnimationType.YAxisMove:
                    MoveYAxisMovement_Yoyo();
                    break;
                case AnimationType.XAxisMove:
                    MoveXAxisMovement_Yoyo();
                    break;
                case AnimationType.Blink:
                    FadeIn();
                    break;
            }
        }

        void MoveYAxisMovement_Yoyo()
        {
            rectTransform.DOLocalMoveY(Value, Time)
            .SetRelative(true)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
        }
        void MoveXAxisMovement_Yoyo()
        {
            rectTransform.DOLocalMoveX(Value, Time)
            .SetRelative(true)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
        }

        static Sequence sequenceFadeIn;
        static Sequence sequenceFadeOut;
        private void FadeIn()
        {
            sequenceFadeIn = DOTween.Sequence()
              .SetAutoKill(false)
              .OnRewind(() =>
              {
              })
              .Append(mysprite.DOFade(1.0f, Time))
              .Append(mysprite.DOFade(0.0f, Time))
              .OnComplete(() =>
              {
                  FadeOut();
              });
        }
        private void FadeOut()
        {
            sequenceFadeOut = DOTween.Sequence()
               .SetAutoKill(false)
               .OnRewind(() =>
               {
               })
               .Append(mysprite.DOFade(0.0f, Time))
               .Append(mysprite.DOFade(1.0f, Time))
               .OnComplete(() =>
               {
                   FadeIn();
               });
        }

        public enum AnimationType
        {
            YAxisMove,
            XAxisMove,
            Blink
        }
    }
}
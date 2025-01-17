using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Client.UI
{
    public class BasePanel : MonoBehaviour
    {
        [Header("Panel Pose On Disable")]
        public Transform DisablePanelPose;

        [Header("Panel Pose On Enable")]
        public Transform EnablePanelPose;

        [Header("TweenMover - Auto Bind")]
        public TweenPanel MyTweenMover;
        
        private void Awake()
        {
            MyTweenMover = GetComponent<TweenPanel>();
        }

        /// <summary>
        /// Open This Panel BY Animation Panel
        /// </summary>
        /// <param name="type"></param>
        public void OpenThisPanel(TweenPanel.AnimationType type)
        {
            gameObject.transform.position = EnablePanelPose.position;
            MyTweenMover.PlayAnimationHandler(type);
        }

        /// <summary>
        /// Open This Panel
        /// </summary>
        public void OpenThisPanel()
        {
            gameObject.transform.position = EnablePanelPose.position;
        }
        
        /// <summary>
        ///  Close This Panel BY Animation Panel
        /// </summary>
        public void CloseThisPanel(TweenPanel.AnimationType type)
        {
            MyTweenMover.PlayAnimationHandler(type);
            MyTweenMover.OnTweenEnd += OnClosePanel;
        }
        
        /// <summary>
        /// Open This Panel
        /// </summary>
        public void CloseThisPanel()
        {
            gameObject.transform.position = DisablePanelPose.position;
            transform.localScale = Vector3.one;
        }
        
        /// <summary>
        /// Tween Close Invoke?
        /// </summary>
        private void OnClosePanel()
        {
            gameObject.transform.position = DisablePanelPose.position;
            MyTweenMover.OnTweenEnd -= OnClosePanel;
            transform.localScale = Vector3.one;
        }

    }
}
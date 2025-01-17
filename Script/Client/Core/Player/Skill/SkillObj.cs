using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using Google.Protobuf.Protocol;
using Script.Client.Manager;

    public class SkillObj : MonoBehaviour
    {
        public Vector3 TargetPos;

        public Skills skillid;
        
        void LateUpdate()
        {
            if(TargetPos==null)
                return;
        
            transform.LookAt(TargetPos);
        }
        
    }
    
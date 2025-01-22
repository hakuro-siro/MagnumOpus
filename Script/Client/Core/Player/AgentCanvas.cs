using System;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace Script.Client.Core.Player
{
    public class AgentCanvas : MonoBehaviour
    {

        public Slider PlayerHP;
        public Image fill;
        public float CurrentHP = 100;
        public float MaxHP = 100;
        [SerializeField] public Transform target;

        private void Start()
        {
            PlayerHP.value = 1;
        }
        private void LateUpdate()
        {
            if(target == null)
                return;
            transform.position = new Vector3(target.position.x,target.position.y+1.5f,target.position.z);
        
        }
        public void OnMe()
        {
            fill.color = Color.green;
        }
        public void OnEnemy()
        {
            fill.color = Color.red;
        }
        
        public void SetPlayerHP(float value)
        {
            float dmg = CurrentHP - value;
            Debug.Log($"enemyhp {dmg/MaxHP}");
            CurrentHP = dmg;
            
            PlayerHP.value = dmg/MaxHP;
        }
    }
}
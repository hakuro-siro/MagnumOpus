using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using Google.Protobuf.Protocol;
using Script.Client.Manager;

public class Skill : MonoBehaviour
{
    //스킬 아이디
    public Skills  skillid;

    public AnimationType animtype;
    //스킬 소유자 아이디
    public CharacterID playerid;
    //스킬로 소환할 오브젝트
    [Header("Skill Object")]
    [SerializeField] public GameObject SkillObject;

    public PlayerSkills skillmanager;
    public event Action<Vector3,AnimationType> OnSkillUse; 
    
    [Header("Skill Setting")]
    public Image skillImage;
    public float cooldown = 5;
    protected bool isCooldown = false;
    [SerializeField]
    protected bool CanUseSkill = true;
    public KeyCode SkillKeycode;


    [Header("Straight Skill Setting")]
    protected Vector3 position;
    public Canvas SkillCanvas;
    public Image SkillShot;
    public Transform player;
    public Transform SkillPos;

    [Header("Cicle Skill Setting")]
    public Image TargetCircle;
    public Image IndicatorRangeCircle;
    protected Vector3 PosUp;
    public float maxAbility2Distance;

    private void Start()
    {
        IStart();
    }

    protected virtual void IStart()
    {

    }

    private void Update()
    {
        IUpdate();
    }

    protected virtual void IUpdate()
    {

    }

    public void InitMySkillManager(PlayerSkills manager)
    {
        skillmanager = manager;
    }

    public void DisableMySkill()
    {
        CanUseSkill = false;
    }
    public void EnableMySkill()
    {
        CanUseSkill = true;
    }

    public void EnvokeSkillUse(Vector3 value,AnimationType type)
    {
        OnSkillUse?.Invoke(value,type);
    }
}


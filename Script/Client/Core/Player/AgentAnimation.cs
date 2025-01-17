using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimation : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    public void PlayAnimation(AnimationType animationType)
    {
        //Debug.Log($"play animationtype : {animationType}");
        switch (animationType)
        {
            case AnimationType.die:
                break;
            case AnimationType.idle:
                Play("Idle");
                break;
            case AnimationType.run:
                Play("Run");
                break;
            case AnimationType.dodge:
                break;
            
            case AnimationType.RapidFire:
                Play("RapidFire");
                break;
            case AnimationType.EMPAttack:
                Play("EMPAttack");
                break;
            case AnimationType.SateliteBeam:
                Play("SateliteBeam");
                break;
            case AnimationType.MultipleShot:
                Play("MultipleShot");
                break;
            case AnimationType.BigShot:
                Play("BigShot");
                break;
            case AnimationType.BrandishingGunFire:
                Play("BrandishingGunFire");
                break;
            case AnimationType.CoreBeam:
                Play("CoreBeam");
                break;
            case AnimationType.GroundScatter:
                Play("GroundScatter");
                break;
            case AnimationType.IceFatalWheel:
                Play("IceFatalWheel");
                break;
            case AnimationType.LumenJudgement:
                Play("LumenJudgement");
                break;
            case AnimationType.FloatingWindStorm:
                Play("FloatingWindStorm");
                break;
            case AnimationType.LightingStrike:
                Play("LightingStrike");
                break;
            case AnimationType.IceRing:
                Play("IceRing");
                break;
            case AnimationType.SprialWheels:
                Play("SprialWheels");
                break;
            
            
            case AnimationType.IceRingInvokeLess:
                Play("IceRingInvokeLess");
                break;
            case AnimationType.RapidFireInvokeLess:
                Play("RapidFireInvokeLess");
                break;
            case AnimationType.EMPAttackInvokeLess:
                Play("EMPAttackInvokeLess");
                break;
            case AnimationType.SateliteBeamInvokeLess:
                Play("SateliteBeamInvokeLess");
                break;
            case AnimationType.MultipleShotInvokeLess:
                Play("MultipleShotInvokeLess");
                break;
            case AnimationType.BigShotInvokeLess:
                Play("BigShotInvokeLess");
                break;
            case AnimationType.BrandishingGunFireInvokeLess:
                Play("BrandishingGunFireInvokeLess");
                break;
            case AnimationType.CoreBeamInvokeLess:
                Play("CoreBeamInvokeLess");
                break;
            case AnimationType.GroundScatterInvokeLess:
                Play("GroundScatterInvokeLess");
                break;
            case AnimationType.IceFatalWheelInvokeLess:
                Play("IceFatalWheelInvokeLess");
                break;
            case AnimationType.LumenJudgementInvokeLess:
                Play("LumenJudgementInvokeLess");
                break;
            case AnimationType.FloatingWindStormInvokeLess:
                Play("FloatingWindStormInvokeLess");
                break;
            case AnimationType.LightingStrikeInvokeLess:
                Play("LightingStrikeInvokeLess");
                break;
            case AnimationType.SprialWheelsInvokeLess:
                Play("SprialWheelsInvokeLess");
                break;
            default:
                break;
        }
    }

    public void Play(string name)
    {
        animator.Play(name, -1, 0f);
    }


    internal void StartAnimation()
    {
        animator.enabled = true;
    }
    internal void StopAnimation()
    {
        animator.enabled = false;
    }
}

public enum AnimationType
{
    die,
    idle,
    run,
    dodge,
    
    RapidFire,
    EMPAttack,
    SateliteBeam,
    MultipleShot,
    BigShot,
    BrandishingGunFire,
    CoreBeam,
    GroundScatter,
    IceFatalWheel,
    LumenJudgement,
    IceRing,
    FloatingWindStorm,
    LightingStrike,
    SprialWheels,
    
    RapidFireInvokeLess,
    EMPAttackInvokeLess,
    SateliteBeamInvokeLess,
    MultipleShotInvokeLess,
    BigShotInvokeLess,
    BrandishingGunFireInvokeLess,
    CoreBeamInvokeLess,
    GroundScatterInvokeLess,
    IceFatalWheelInvokeLess,
    LumenJudgementInvokeLess,
    IceRingInvokeLess,
    FloatingWindStormInvokeLess,
    LightingStrikeInvokeLess,
    SprialWheelsInvokeLess
}
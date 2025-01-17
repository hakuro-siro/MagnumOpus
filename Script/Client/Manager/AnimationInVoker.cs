using System;
using UnityEngine;

namespace Script.Client.Manager
{
    public class AnimationInVoker : MonoBehaviour
    {
        public static AnimationInVoker instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public event Action OnAnimRapidFire;

        public void InvokeRapidFire()
        {
            Debug.LogWarning("invoked?");
            OnAnimRapidFire?.Invoke();
        }
        public event Action OnAnimEmpAttack;
        public void InvokeEMPAttack()
        { Debug.LogWarning("invoked?");
            OnAnimEmpAttack?.Invoke();
        }
        public event Action OnAnimSateliteBeam;
        public void InvokeSateliteBeam()
        { Debug.LogWarning("invoked?");
            OnAnimSateliteBeam?.Invoke();
        }
        public event Action OnAnimMultipleShot;
        public void InvokeMultipleShot()
        { Debug.LogWarning("invoked?");
            OnAnimMultipleShot?.Invoke();
        }
        public event Action OnAnimBigShot;
        public void InvokeBigShot()
        { Debug.LogWarning("invoked?");
            OnAnimBigShot?.Invoke();
        }
        public event Action OnAnimBrandishingGunFire;
        public void InvokeBrandishingGunFire()
        { Debug.LogWarning("invoked?");
            OnAnimBrandishingGunFire?.Invoke();
        }
        public event Action OnAnimCoreBeam;
        public void InvokeCoreBeam()
        { Debug.LogWarning("invoked?");
            OnAnimCoreBeam?.Invoke();
        }
        public event Action OnAnimGroundScatter;
        public void InvokeGroundScatter()
        { Debug.LogWarning("invoked?");
            OnAnimGroundScatter?.Invoke();
        }
        public event Action OnAnimIceFatalWheel;
        public void InvokeIceFatalWheel()
        { Debug.LogWarning("invoked?");
            OnAnimIceFatalWheel?.Invoke();
        }
        public event Action OnAnimLumenJudgement;
        public void InvokeLumenJudgement()
        { Debug.LogWarning("invoked?");
            OnAnimLumenJudgement?.Invoke();
        }
        public event Action OnAnimIceRing;
        public void InvokeIceRing()
        { Debug.LogWarning("invoked?");
            OnAnimIceRing?.Invoke();
        }
        public event Action OnAnimFloatingWindStorm;
        public void InvokeFloatingWindStorm()
        { Debug.LogWarning("invoked?");
            OnAnimFloatingWindStorm?.Invoke();
        }
        public event Action OnAnimLightingStrike;
        public void InvokeLightingStrike()
        { Debug.LogWarning("invoked?");
            OnAnimLightingStrike?.Invoke();
        }
        public event Action OnAnimSprialWheels;
        public void InvokeSprialWheels()
        { Debug.LogWarning("invoked?");
            OnAnimSprialWheels?.Invoke();
        }
    }
}
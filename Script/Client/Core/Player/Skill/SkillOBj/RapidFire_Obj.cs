using System;
using Script.Client.Manager;
using UnityEngine;


public class RapidFire_Obj : SkillObj
{
    public float speed = 5;
    Vector3 lookDir;

    void LateUpdate()
    {
        if(TargetPos==null)
            return;
        
        transform.LookAt(TargetPos);
        
        lookDir = (TargetPos - transform.position).normalized;
        transform.position +=  lookDir * speed * Time.deltaTime;
        
        //임시니까 나중에 바꿔!
        if ((int)transform.position.x == (int)TargetPos.x)
        {
            if ((int)transform.position.z == (int)TargetPos.z)
            {
                Destroy(this.gameObject);
            }
        }
    }
    
    
}
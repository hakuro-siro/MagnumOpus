using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] public Transform target;

    private void LateUpdate()
    {
        if(target == null)
            return;
        transform.position = target.position;
        
    }
}
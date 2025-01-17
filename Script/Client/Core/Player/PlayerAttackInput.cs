using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PlayerAttackInput : MonoBehaviour
{

    /// <summary>
    /// Get Input Field 
    /// </summary>
    [field: SerializeField]

    // Does not need Value Event System
    public event Action OnAttackQ, OnAttackW, OnAttackE, OnAttackR;


    private void Update()
    {
        if (Time.timeScale > 0)
        {
            GetPosWithAtkRange();
        }

    }

    private bool GetPosWithAtkRange()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
        //Debug.Log(hit.point);
        if (hasHit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log(hit.point);

            }
            return true;
        }
        return false;
    }

    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

}

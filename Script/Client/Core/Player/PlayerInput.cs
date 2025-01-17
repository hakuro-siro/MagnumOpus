using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using System;
using Script.Client.Manager;

/// <summary>
/// Player Inputs! 
/// </summary>
public class PlayerInput : MonoBehaviour
{

    /// <summary>
    /// Get Input Field 
    /// </summary>
    [field: SerializeField]
    public Vector2 MovementVector { get; private set; }

    [field: SerializeField] public bool IsNetwork = false;
    // Does not need Value Event System
    public event Action OnWeaponChange;
    
    // need Value Event System
    public event Action<Vector3> OnMovement;
    
    public UnityEvent OnMenuKeyPressed;

    public Agent agent;
    private void Start()
    {
        
    }

    private void Update()
    {
        if(IsNetwork)
            if (agent.networkobjData.Objid != MagicaClientMain.instance.playerDataManager.GetControllObject())
                return;
        if (Time.timeScale > 0)
        {
            GetPosWithMovement();
            GetWeaponSwapInput();
        }
       
    }

    private bool GetPosWithMovement()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
        

        if (hasHit)
        {
            //Debug.Log("Hit");

            if (Input.GetMouseButtonDown(1))
            {
//                Debug.Log("Hit position"+hit.point);
                OnMovement?.Invoke(hit.point);
            }
            return true;
        }
        return false;
    }

    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
    
    private void GetWeaponSwapInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnWeaponChange?.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Script.Client.Manager;
using UnityEngine;

/// <summary>
/// player Behaviors
/// </summary>
[CreateAssetMenu(fileName = "CharacterData",menuName = "Character/Data")]
public class AgentDataSO : ScriptableObject
{
    /// <summary>
    /// Demo
    /// </summary>
    [Header("Character ID")] public CharacterID ID;
    
    [Header("Movement data")] [Space]
    public float maxSpeed = 6;
    

}

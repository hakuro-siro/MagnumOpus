using Script.Client.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// player Behaviors
/// </summary>
[CreateAssetMenu(fileName = "PlayerData",menuName = "Player/Data")]
public class PlayerDataSO : ScriptableObject
{
    [Header("Player ID")] [Space]
    
    public int PlayerID;

    [Header("Selected Character")] [Space]

    public CharacterID CharacterID;

    [Header("Selected Skills")] [Space]
    public string Slot1Data;
    public string Slot2Data;
    public string Slot3Data;
    public string Slot4Data;

    public string SelectedSupportData;

    
    [Header("Controlling PlayerID")] public int ControllingObjID;

}
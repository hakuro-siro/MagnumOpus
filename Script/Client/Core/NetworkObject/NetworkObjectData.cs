using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkObjectData : MonoBehaviour
{
    [Header(("Object Id"))] [Space] 
    public int Objid = 0;
    [Header("Object Position")] [Space]
    public Vector3 StartPos;
}

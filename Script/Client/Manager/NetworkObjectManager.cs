using System.Collections.Generic;
using UnityEngine;

namespace Script.Client.Manager
{
    /// <summary>
    ///  NetworkManager에서 받은 Invoke로 인한 오브젝트 생성 등에 대응,
    ///  이로 인해 생성된 오브젝트에 대하여 관리
    /// </summary>
    
    public enum GameObjectType
    {
        None = 0,
        Player = 1,
        Monster = 2,
        Projectile = 3
    }

    public class NetworkObjectManager : MonoBehaviour
    {
        public static int GetSkillIdById(int id)
        {
            int type = (id >> 20) & 0b00001111;
            return type;
        }

        public static GameObjectType GetObjectTypeById(int id)
        {
            int type = (id >> 24) & 0x7F;
            return (GameObjectType)type;
        }
    }
}
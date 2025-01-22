using Google.Protobuf.Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{    
    
    public static Mover instance = null;

    void Awake(){
        if(instance == null){
            instance = this;
        }
    }
    [SerializeField] private Transform target;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }

        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);

        float speed = localVelocity.z;
        
        //GetComponent<Animator>().SetFloat("forwardSpeed",speed);

    }
    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit =  Physics.Raycast(ray,out hit);
        if (hasHit)
        {
            //Debug.Log(hit.point);
            C_Move pkt = new C_Move();
            PositionInfo posinfo = new PositionInfo();
            posinfo.PosX = hit.point.x;
           posinfo.PosY = hit.point.y;

           Vector3 point = new Vector3(
                (float)Math.Truncate(hit.point.x * 10) / 10, 
                (float)Math.Truncate(hit.point.y * 10) / 10,
                (float)Math.Truncate(hit.point.z * 10) / 10);
            Debug.Log(point);
            posinfo.PosX = point.x;
            posinfo.PosY = point.y;
            pkt.PosInfo = posinfo;
            NetworkManager.Instance.Send(pkt);
            GetComponent<NavMeshAgent>().destination = point;
        }
    }
    public void MoveObject(PositionInfo posinfo)
    {
        Vector3 movepos = new Vector3(posinfo.PosX, posinfo.PosY, 0);
        GetComponent<NavMeshAgent>().destination = movepos;
    }
}

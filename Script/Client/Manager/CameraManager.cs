using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera UICamera;
    public Camera InGameSceneCamera;

    
    public void SetInGameSceneCamera(Camera cam)
    {
        InGameSceneCamera = cam;
        UICamera.enabled = false;
    }

    public void OutInGameSceneCamera()
    {
        UICamera.enabled = true;
    }
}

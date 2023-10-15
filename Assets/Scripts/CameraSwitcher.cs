using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public static class CameraSwitcher
{
    // static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    // public static CinemachineVirtualCamera activeCamera = null;

    // public static CinemachineVirtualCamera ActiveCamera

    static List<Camera> cameras = new List<Camera>();

    public static Camera activeCamera = null;

    public static Camera ActiveCamera
    {
        get { return activeCamera; }
    }

    public static bool IsActiveCamera(Camera camera)
    {
        return camera == activeCamera;
    }

    public static void SwitchCamera(Camera camera)
    {
        //camera.Priority = 20;
        activeCamera = camera;

        // foreach (Camera c in cameras)
        // {
        //     if (c != camera && c.Priority != 0)
        //     {
        //         c.Priority = 0;
        //     }
        // }
    }

    public static void RegisterCamera(Camera camera)
    {
        cameras.Add(camera);
        Debug.Log("Camera registered" + camera.name);
    }

    public static void UnregisterCamera(Camera camera)
    {
        cameras.Remove(camera);
        Debug.Log("Camera unregistered" + camera.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraController : MonoBehaviour
{
    //public List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    public List<Camera> cameras = new List<Camera>();
    private int activeCameraIndex = 0;

    private SpriteRenderer sprite;

    private void OnEnable() 
    {
        sprite = GetComponent<SpriteRenderer>();
        foreach (Camera camera in cameras)
        {
            CameraSwitcher.RegisterCamera(camera);
        }
    }

    private void OnDisable() {
        foreach (Camera camera in cameras)
        {
            CameraSwitcher.UnregisterCamera(camera);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");

            activeCameraIndex = (activeCameraIndex + 1) % cameras.Count;
            CameraSwitcher.SwitchCamera(cameras[activeCameraIndex]);

            transform.LookAt(new Vector3(cameras[activeCameraIndex].transform.position.x, transform.position.y, cameras[activeCameraIndex].transform.position.z));

            Debug.Log("activeCameraIndex: " + activeCameraIndex);
        }
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q pressed");

            activeCameraIndex--;
            if (activeCameraIndex < 0)
            {
                activeCameraIndex = cameras.Count - 1;
            }
            
            CameraSwitcher.SwitchCamera(cameras[activeCameraIndex]);
            transform.LookAt(new Vector3(cameras[activeCameraIndex].transform.position.x, transform.position.y, cameras[activeCameraIndex].transform.position.z));

            Debug.Log("activeCameraIndex: " + activeCameraIndex);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    Camera cam1;
    Camera cam2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.LookAt(cam1.transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.LookAt(cam2.transform.position);
        }
    }
}

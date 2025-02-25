using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//카메라의 비율을 항상 9:16으로 유지하는 코드
//완. OK.
public class CameraResolution : MonoBehaviour
{
    private float targetAspect = 9f / 16f;
    void Start()
    {
        Camera cam = GetComponent<Camera>();

        float screenAspect = (float)Screen.width / Screen.height;
        float scale = screenAspect / targetAspect;

        if (scale < 1.0f)
        {
            cam.orthographicSize = cam.orthographicSize / scale;
        }

        else if (scale > 1.0f)
        { 
            cam.orthographicSize = cam.orthographicSize * scale;
        }

        

    }

    void OnPreCull() => GL.Clear(true, true, Color.black);
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//ī�޶��� ������ �׻� 9:16���� �����ϴ� �ڵ�
//��. OK.
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

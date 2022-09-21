using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_09_07_ZoomInOut : MonoBehaviour
{
    float scrollWheel;
    float t;
    float a;
    float b;
    // Start is called before the first frame update
    void Start()
    {
        t = 0f;
        a = Camera.main.fieldOfView;
        b = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float s = Input.GetAxis("Mouse ScrollWheel");
        if (s != 0)
        {
            scrollWheel = s;
            a = Camera.main.fieldOfView;
            b = a + scrollWheel * 50f;
            t = 0f;
        }
        float curFov = Mathf.Lerp(a,b,t);
        t += 8f * Time.deltaTime;
        Camera.main.fieldOfView = curFov;
    }
}

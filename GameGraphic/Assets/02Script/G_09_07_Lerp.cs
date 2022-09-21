using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_09_07_Lerp : MonoBehaviour
{
    public float minimum = -1.0f;
    public float maximum = 1.0f;

    public float t = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 0, 0);
        t += 0.5f * Time.deltaTime;
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}

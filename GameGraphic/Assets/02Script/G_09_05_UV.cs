using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_09_05_UV : MonoBehaviour
{
    MeshRenderer render;
    int offsetIndex;
    float elapsed;

    int column;
    int row;
    int totalFrameCount;
    Vector2 size;       //출력할 텍스쳐 상에서 한 프레임의 크기 
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        offsetIndex = 0;
        elapsed = 0;
        column = 4;
        row = 2;
        size.x = 1.0f / column;
        size.y = 1.0f / row;
        totalFrameCount = column * row;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed -= 1f;
            offsetIndex++;
            if (offsetIndex >= totalFrameCount)
                offsetIndex = 0;
        }

        //출력되는 위치를 1초마다 증가
        float u = offsetIndex / column;
        float v = offsetIndex % column;
        Vector2 offset = new Vector2(v * size.x, (1-size.y) - u*size.y);
        render.material.SetTextureOffset("_MainTex",offset);
        render.material.SetTextureScale("_MainTex",size);


    }
}

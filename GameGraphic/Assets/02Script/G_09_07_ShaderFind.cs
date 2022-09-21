using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_09_07_ShaderFind : MonoBehaviour
{
    //셰이더를 실시간 교체하는 스크립트
    // Start is called before the first frame update
    void Start()
    {
        SkinnedMeshRenderer render = GetComponentInChildren<SkinnedMeshRenderer>();
        if (render != null)
            render.material.shader = Shader.Find("Mobile/Diffuse");
        List<SkinnedMeshRenderer> resultList = new List<SkinnedMeshRenderer>();
        GetComponentsInChildren<SkinnedMeshRenderer>(resultList);
        foreach(SkinnedMeshRenderer one in resultList)
        {
            Debug.Log(one);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

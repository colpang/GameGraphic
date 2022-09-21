using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_09_02_Material : MonoBehaviour
{
    public GameObject Cube;
    Texture2D rcTexture;
    Texture2D rcTexture2;
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rcTexture = Resources.Load<Texture2D>("Longsword");
        rcTexture2 = Resources.Load<Texture2D>("02_Fire");
        meshRenderer = Cube.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            meshRenderer.material.SetTexture("_MainTex", rcTexture);
            //meshRenderer.material.mainTexture = rcTexture;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            meshRenderer.material.SetTexture("_MainTex", rcTexture2);
            //meshRenderer.material.mainTexture = rcTexture2;
        }
        //텍스쳐 오프셋 변경
        Vector2 textureOffset = meshRenderer.material.mainTextureOffset;
        textureOffset.x += Time.deltaTime;
        meshRenderer.material.mainTextureOffset = textureOffset;
    }
}

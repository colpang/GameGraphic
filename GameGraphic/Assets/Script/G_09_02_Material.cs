using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_09_02_Material : MonoBehaviour
{
    public GameObject Cube;
    Texture2D rcTexture;
    Texture2D rcTexture2;
    // Start is called before the first frame update
    void Start()
    {
        rcTexture = Resources.Load<Texture2D>("Longsword");
        rcTexture2 = Resources.Load<Texture2D>("02_Fire");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Cube.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", rcTexture);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Cube.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", rcTexture2);
        }
        Vector2 textureOffset = Cube.GetComponent<MeshRenderer>().material.mainTextureOffset;
        textureOffset.x += Time.deltaTime;
        Cube.GetComponent<MeshRenderer>().material.mainTextureOffset = textureOffset;
    }
}

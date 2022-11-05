using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_09_20_GPUInstancing : MonoBehaviour
{
    List<GameObject> objects;
    // Start is called before the first frame update
    void Start()
    {
        objects = new List<GameObject>();
        GameObject tmp = Resources.Load<GameObject>("GPUInstancing_Sphere");
        for(int i = 0; i < 10; i++)
        {
            GameObject createObject = GameObject.Instantiate<GameObject>(tmp);
            objects.Add(createObject);
        }


        MaterialPropertyBlock props = new MaterialPropertyBlock();
        MeshRenderer renderer;
        foreach (GameObject obj in objects)
        {
            float r = Random.Range(0.01f,1.0f);
            float g = Random.Range(0.01f,1.0f);
            float b = Random.Range(0.01f,1.0f);
            props.SetColor("_Color",new Color(r,g,b));

            renderer = obj.GetComponent<MeshRenderer>();
            renderer.SetPropertyBlock(props);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

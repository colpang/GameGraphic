using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_09_15_AlphaBlendingP : MonoBehaviour
{
    MeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = new MeshRenderer();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (transform.position - Camera.main.transform.position).normalized;
        Debug.DrawLine(Camera.main.transform.position, transform.position,Color.red);
        RaycastHit[] hitinfo;
        hitinfo = Physics.RaycastAll(Camera.main.transform.position, dir, 100.0f);

        foreach (RaycastHit one in hitinfo)
        {
            renderer = one.collider.GetComponent<MeshRenderer>();
            Color col = one.collider.GetComponent<MeshRenderer>().material.color;
            
            if (one.collider)
            {
                Debug.Log(renderer.gameObject.name);
                col.a = 0.1f;
                one.collider.GetComponent<MeshRenderer>().material.color = col;
            }

            for(int i = 0; i < hitinfo.Length; i++)
            {
                if (hitinfo[i].collider!= one.collider)
                {
                    Debug.Log("out:"+hitinfo[i].collider.name);
                    col.a = 1f;
                    hitinfo[i].collider.GetComponent<MeshRenderer>().material.color = col;
                }
            }
        }
        
    }
}

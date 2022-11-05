using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_09_20_GPUInstancing_P : MonoBehaviour
{
    GameObject rc;
    List<GameObject> objects;
    MaterialPropertyBlock tmpProps;
    // Start is called before the first frame update
    void Start()
    {
        tmpProps= new MaterialPropertyBlock();
        objects = new List<GameObject>();
        rc = Resources.Load<GameObject>("GPUInstancing_Sphere");

    }

    void createObj()
    {
        GameObject createObject = GameObject.Instantiate<GameObject>(rc);
        /*Renderer renderer = createObject.GetComponent<MeshRenderer>();
        MaterialPropertyBlock props = new MaterialPropertyBlock();
        props.SetColor("_Color", new Color(1f,1f,1f));
        renderer.SetPropertyBlock(props);*/
        createObject.transform.position = new Vector3(Random.Range(0,10),2, Random.Range(0, 10));
        objects.Add(createObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            createObj();
        }


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            if (Physics.Raycast(ray, out hitinfo, Mathf.Infinity))
            {
                MeshRenderer renderer = hitinfo.collider.gameObject.GetComponent<MeshRenderer>();
                if (renderer != null)
                {
                    renderer.GetPropertyBlock(tmpProps);
                    tmpProps.SetColor("_Color",new Color(0,0,0,0.3f));
                    renderer.SetPropertyBlock(tmpProps);
                }
               
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_09_07_GetChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform findTr = findGameObjectInChild("Bip001 Neck", transform);
        if (findTr != null)
            Debug.Log(findTr.name);
    }

    public Transform findGameObjectInChild(string nodename, Transform origin)
    {
        if (origin.name == nodename)
            return origin;
        for (int i = 0;i< origin.childCount;i++) {
            Transform childTr= findGameObjectInChild(nodename, origin.GetChild(i));
            if (childTr != null)
                return childTr;
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

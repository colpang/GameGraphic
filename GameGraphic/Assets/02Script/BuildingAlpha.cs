using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAlpha : MonoBehaviour
{
    //알파(반투명화)가 적용된 리스트
    List<GameObject> Alphalist = new List<GameObject>();
    //원래대로 복원해야하는 리스트 
    List<GameObject> Recoverlist = new List<GameObject>();
    public GameObject player;
    void Start()
    {

    }
    // obj가 알파리스트에 포함되어 있는지 검사
    public GameObject FindAlphalist(GameObject obj)
    {
        GameObject findObj = Alphalist.Find(o => (o.name == obj.name));
        return findObj;
    }
    public void AddAlplalist(GameObject obj)
    {
        GameObject alphaObj = FindAlphalist(obj);
        if (alphaObj == null)
        {
            Debug.Log("flag");
            Alphalist.Add(obj);
            Color col = obj.GetComponent<MeshRenderer>().material.color;
            col.a = 0.2f;
            obj.GetComponent<MeshRenderer>().material.color = col;
        }
    }
    private void LateUpdate()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 dir = player.transform.position - Camera.main.transform.position;
        RaycastHit[] hits = Physics.RaycastAll(origin, dir.normalized);

        //충돌한 것이 없을 경우
        //전부 복원하고 return
        if (hits.Length == 0) 
        {

            for (int i = 0; i < Alphalist.Count; i++)
            {
                Color col = Alphalist[i].GetComponent<MeshRenderer>().material.color;
                col.a = 1f;
                Alphalist[i].GetComponent<MeshRenderer>().material.color = col;
            }
            Alphalist.Clear();
            return;
        }

        // 광선과 충돌한 게임오브젝트 전체를 리스트에 저장
        // 반투명해진 게임오브젝트들
        for (int i = 0; i < hits.Length; i++)
        {
            AddAlplalist(hits[i].collider.gameObject);
        }
        // 복원구현
        // 알파리스트에서 빠져나간 경우
        for (int i = 0; i < Alphalist.Count; i++)
        {
            GameObject tmp = null;
            for (int j = 0; j < hits.Length; j++)
            {
                try
                {
                    if (Alphalist[i].name == hits[j].collider.gameObject.name)
                    {
                        tmp = hits[j].collider.gameObject;
                    }
                }
                catch (System.IndexOutOfRangeException e)
                {
                    Debug.Log("i index = " + i);
                    Debug.Log("j index = " + j);
                }
            }
            //만약 알파리스트에서 빠져나가 tmp가 null인 채일 경우
            if (tmp == null)
            {

                GameObject recoverObj = Recoverlist.Find(o => (o.name == Alphalist[i].name));
                if (recoverObj != null)
                    continue;
                Color col = Alphalist[i].GetComponent<MeshRenderer>().material.color;
                col.a = 1f;
                Alphalist[i].GetComponent<MeshRenderer>().material.color = col;
                Recoverlist.Add(Alphalist[i]);
            }
        }
        // Recoverlist에 있는 오브젝트를 Alphalist에서 제거
        int size = Recoverlist.Count;
        for (int i = 0; i < size; i++)
        {
            try
            {
                GameObject findObj = Alphalist.Find(o => (o.name == Recoverlist[i].name));
                if (findObj != null)
                {
                    Alphalist.Remove(findObj);
                }
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Debug.Log("i index = " + i);
            }
        }
        Recoverlist.Clear();
    }
}


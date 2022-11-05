using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_09_15_AlphaBlendingP : MonoBehaviour
{
    //게임오브젝트의 원래 컬러 리스트
    //레이와 교차한 게임오브젝트들을 배열에 저장할 리스트
    List<GameObject> Alphalist = new List<GameObject>();
    List<GameObject> Recoverlist = new List<GameObject>();
    //플레이어
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    //알파리스트 추가 함수
    //알파리스트에 없는 오브젝트일 경우 알파리스트에 원래 컬러 추가
    //추가 후 오브젝트의 alpha값을 0.2f로 변경(반투명화)
    public void AddAlplalist(GameObject obj)
    {
        GameObject alphaObj = FindAlphalist(obj);
        if (alphaObj == null)
        {
            Alphalist.Add(obj);
            //색상변경
            Color col = obj.GetComponent<MeshRenderer>().material.color;
            col.a = 0.2f;
            obj.GetComponent<MeshRenderer>().material.color = col;
        }
    }

    // obj가 알파리스트에 포함되어 있는지 검사
    public GameObject FindAlphalist(GameObject obj)
    {
        GameObject findObj = Alphalist.Find(o => (o.name == obj.name));
        return findObj;
    }

    // Update is called once per frame
    void Update()
    {
        //origin = 카메라 위치 벡터
        //dir = 카메라에서 플레이어로 향하는 벡터
        Vector3 origin = Camera.main.transform.position;
        Vector3 dir = player.transform.position - Camera.main.transform.position;
        //레이캐스트
        RaycastHit[] hits = Physics.RaycastAll(origin, dir.normalized);
        //카메라와 플레이어 사이에 아무 오브젝트도 없을 경우
        if (hits.Length == 0)
        {
            for (int i = 0; i < Alphalist.Count; i++)
            {
                //알파리스트에 있는 모든 오브젝트의 컬러의 알파값을 1로 돌림(불투명화)
                Color col = Alphalist[i].GetComponent<MeshRenderer>().material.color;
                col.a = 1f;
                Alphalist[i].GetComponent<MeshRenderer>().material.color = col;
            }
            //알파리스트를 전부 비우고 return (이하의 코드를 실행하지 않음)
            Alphalist.Clear();
            return;
        }

        //충돌한 오브젝트가 있을 경우 광선과 충돌한 게임오브젝트 전체를 리스트에 저장
        for (int i = 0; i < hits.Length; i++)
        {
            AddAlplalist(hits[i].collider.gameObject);
        }
        // 복원구현
        // 알파리스트에서 빠져나간 경우
        //알파 리스트에 들어간 게임오브젝트 수만큼 이하를 반복
        for (int i = 0; i < Alphalist.Count; i++)
        {
            GameObject tmp = null;

            //충돌한 오브젝트 수만큼 반복
            //알파리스트에 들어간 오브젝트 중 현재 충돌중인 오브젝트를 tmp에 저장
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
            //현재 충돌중인 오브젝트가 
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

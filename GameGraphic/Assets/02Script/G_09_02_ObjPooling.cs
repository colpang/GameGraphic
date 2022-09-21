using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_09_02_ObjPooling : MonoBehaviour
{
    public List<G_09_02_Monster> monsterList;

    // Start is called before the first frame update
    void Awake()
    {
        monsterList = new List<G_09_02_Monster>();
    }

    private void Start()
    {
        for(int i=0; i < 10; i++)
        {
            string name = "Monster" + (i+1).ToString();
            G_09_02_Monster monsterScript = CreateMonster(name);
        }
    }

    public G_09_02_Monster CreateMonster(string name)
    {
        //����Ʈ���� �����ϰ��� �ϴ� ���ӿ�����Ʈ�� �̸��� ������ ���ӿ�����Ʈ�� ��Ȱ��ȭ�� ���ӿ�����Ʈ�� �˻�
        G_09_02_Monster monsterScript = monsterList.Find(o => ( o.gameObject.name.Equals(name) && 
                                                                o.gameObject.activeSelf == false));
        //����� �� �ִ� ��Ȱ��ȭ�� ���Ͱ� ����
        if(monsterScript != null)
        {
            monsterScript.gameObject.SetActive(true);
            return monsterScript;
        }
        else
        {
            //���� �����ؾ��ϴ� ���
            GameObject rcMonster = Resources.Load<GameObject>("TestCube");
            GameObject monsterObj = Instantiate<GameObject>(rcMonster);
            G_09_02_Monster newMonster = monsterObj.AddComponent<G_09_02_Monster>();
            newMonster.gameObject.name = "Monster" + Random.Range(1, 11).ToString();
            newMonster.transform.position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
            monsterList.Add(newMonster);
            return newMonster;
        }
    }
    public void RemoveMonster(string name)
    {
        G_09_02_Monster monsterScript = monsterList.Find(o => (o.gameObject.name.Equals(name) 
                                                         && o.gameObject.activeSelf == true));
        if(monsterScript != null)
            monsterScript.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string name = "Monster" + Random.Range(1, 11).ToString();
            RemoveMonster(name);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            string name = "Monster" + Random.Range(1, 11).ToString();
            G_09_02_Monster monsterScript = CreateMonster(name);
        }
    }
}

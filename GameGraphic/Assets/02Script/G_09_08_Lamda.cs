using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//��ȯ������ void�̰� �Ű������� ���� ��������Ʈ ����
public delegate int Do(int _a);
public delegate int DoN();
public delegate void DoV();
public class G_09_08_Lamda : MonoBehaviour
{
    Do doSomething;
    DoN doSomethingN;
    DoV doSomethingV;

    //�����ذ�
    DoV Todo;
    // Start is called before the first frame update
    void Start()
    {
        //���ٽ� ��������Ʈ �Լ� ����
        //�Ű����� O �Ķ���
        doSomething = (x) => x * x;
        //�Ű����� X �Ķ���, �� ��쿡�� ���� ���X
        doSomethingN = () => 2 * 2;

        doSomethingV = () => { Debug.Log("123"); };
        //doSomething�� ���ٽ����� ������ �Լ��� ������ ����
        int result = doSomething(4);
        int result2 = doSomethingN();

        Debug.Log("���:"+result);
        Debug.Log("���:"+result2);

        doSomething = (x) =>
        {
            int result = x * x+100;
            return result;
        };
        Test(doSomething,4);

        List<int> list = new List<int>();
        for(int i=0;i<1;i++)
            list.Add(i);

        //var tmp = list.Find(o => o.Equals(99));
        //Nullable ����ص� null ��ȯX
        int? tmp = list.Find(o => o.Equals(99));
        if (tmp.HasValue)
            Debug.Log(tmp);
        else
            Debug.Log("Null");
        Debug.Log(tmp);

        Todo = null;
    }

    public int? findData(List<int> list, int findData)
    {
        foreach (int one in list)
        {
            if (one.Equals(findData))
            {
                return one;
            }
        }
        return null;
    }
    public void Test(Do doSomething,int arg)
    {
        int result = doSomething(arg);
        Debug.Log("test:" + result);
    }
    // Update is called once per frame

    //���� �ذ�
    //Update�Լ����� ���ǹ��� �ѹ��� ����Ͽ�
    //Ư�� �̺�Ʈ���� ���� �Լ� ȣ���� �� �� �ִ� ���α׷� �ڵ带 �ۼ��Ͻÿ�

    //Ư�� �̺�Ʈ�� �߻����� �� ȣ���ϴ� �Լ�
    public void setEvent(int eventIndex, DoV todo)
    {
        Debug.Log(eventIndex + "�̺�Ʈ �߻�");
        Todo = todo;
    }
    public void EventAction()
    {
        Debug.Log("EventAction");
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            setEvent(2,EventAction);
        }
        if (Todo != null)
        {
            Todo();
            Todo = null;
        }

    }
}

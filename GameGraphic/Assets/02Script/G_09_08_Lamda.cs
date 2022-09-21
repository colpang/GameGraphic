using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//반환형식이 void이고 매개변수가 없는 델리게이트 선언
public delegate int Do(int _a);
public delegate int DoN();
public delegate void DoV();
public class G_09_08_Lamda : MonoBehaviour
{
    Do doSomething;
    DoN doSomethingN;
    DoV doSomethingV;

    //문제해결
    DoV Todo;
    // Start is called before the first frame update
    void Start()
    {
        //람다식 델리게이트 함수 정의
        //매개변수 O 식람다
        doSomething = (x) => x * x;
        //매개변수 X 식람다, 이 경우에는 변수 사용X
        doSomethingN = () => 2 * 2;

        doSomethingV = () => { Debug.Log("123"); };
        //doSomething은 람다식으로 정의한 함수의 구문을 실행
        int result = doSomething(4);
        int result2 = doSomethingN();

        Debug.Log("결과:"+result);
        Debug.Log("결과:"+result2);

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
        //Nullable 사용해도 null 반환X
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

    //문제 해결
    //Update함수에서 조건문을 한번만 사용하여
    //특정 이벤트에만 대한 함수 호출을 할 수 있는 프로그램 코드를 작성하시오

    //특정 이벤트가 발생했을 때 호출하는 함수
    public void setEvent(int eventIndex, DoV todo)
    {
        Debug.Log(eventIndex + "이벤트 발생");
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

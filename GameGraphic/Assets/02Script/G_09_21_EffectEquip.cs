using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_09_21_EffectEquip : MonoBehaviour
{
    public Transform RHand;
    GameObject resource;

    string effectDummyPath = "RHandEffect";
    public TrailRenderer swordEffect;
    // Start is called before the first frame update
    void Start()
    {
        resource = Resources.Load<GameObject>("FireEffect");
        //GameObject.Find함수의 단점
        //씬의 모든 게임오브젝트를 검사하여 연산량이 많아짐
        //+활성화된 게임오브젝트만 검색함
        //비활성화된 게임오브젝트일 경우 transform의 검색함수를 사용해야함
        //transform의 검색함수 > childCount 등..
        RHand = findChildTransform(effectDummyPath, transform);
        swordEffect.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject effect = Instantiate<GameObject>(resource, RHand.position, Quaternion.identity, RHand);
        }
    }
    
    public void SwordEffectOn()
    {
        swordEffect.enabled = true;
    }
    public void SwordEffectOff()
    {
        swordEffect.enabled = false;
    }
    public Transform findChildTransform(string nodeName, Transform origin)
    {
        //재귀 함수에서는 return이 반드시 존재해야함 = 끝이 명확해야함. basecase
        //바로 자신이 일치할 경우 return 후 종료
        if (origin.name == nodeName)
            return origin;
        //자식의 개수만큼 루프를 돔
        //재귀호출이 무한정 반복되면 stack overflow가 발생함 
        for(int i = 0; i < origin.childCount; i++)
        {
            //자식의 트랜스폼을 함수에 전달
            Transform findTr = findChildTransform(nodeName, origin.GetChild(i));
            if (findTr != null)
                return findTr;
        }
        return null;
    }
}

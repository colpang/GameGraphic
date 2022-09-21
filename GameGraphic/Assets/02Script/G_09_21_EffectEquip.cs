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
        //GameObject.Find�Լ��� ����
        //���� ��� ���ӿ�����Ʈ�� �˻��Ͽ� ���귮�� ������
        //+Ȱ��ȭ�� ���ӿ�����Ʈ�� �˻���
        //��Ȱ��ȭ�� ���ӿ�����Ʈ�� ��� transform�� �˻��Լ��� ����ؾ���
        //transform�� �˻��Լ� > childCount ��..
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
        //��� �Լ������� return�� �ݵ�� �����ؾ��� = ���� ��Ȯ�ؾ���. basecase
        //�ٷ� �ڽ��� ��ġ�� ��� return �� ����
        if (origin.name == nodeName)
            return origin;
        //�ڽ��� ������ŭ ������ ��
        //���ȣ���� ������ �ݺ��Ǹ� stack overflow�� �߻��� 
        for(int i = 0; i < origin.childCount; i++)
        {
            //�ڽ��� Ʈ�������� �Լ��� ����
            Transform findTr = findChildTransform(nodeName, origin.GetChild(i));
            if (findTr != null)
                return findTr;
        }
        return null;
    }
}

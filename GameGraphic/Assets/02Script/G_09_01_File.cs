using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;


public class G_09_01_File : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //���ڿ� �����͸� ����Ʈ�� ��ȯ�ϰ� ����Ʈ �迭�� �̿��Ͽ� ���Ͽ� ����
        string writeString = "10,20,30,40,���";
        byte[] writeByte = Encoding.Default.GetBytes(writeString);
        File.WriteAllBytes(Application.dataPath + "/" + "test.txt",writeByte);
        //����Ʈ �迭�� �о� ���ڿ��� ��ȯ�� �ֺܼ信 ���
        byte[] readBytes = File.ReadAllBytes(Application.dataPath + "/" + "test.txt");
        string readString = Encoding.Default.GetString(readBytes);
        Debug.Log(readString);

        //���ڿ������Լ�
        //1.Trim
        //����/���� ���� ��� ����
        string message = " 100,200,300,400 ";
        string result = message.Trim();
        Debug.Log("Trim:"+result);
        //2.Replace
        //Ư�� ���ڸ� ������ ���ڷ� ��ü
        result = message.Replace(",","_");
        Debug.Log("Replace:"+result);
        //3.Split
        //Ư�� ���ڸ� �������� �и�, �迭�� ��ȯ
        string[] splitData = result.Split("_");
        foreach (string one in splitData)
            Debug.Log(one);
        //���ڿ��� ������ ��ȯ�Ϸ���
        int outResult;
        if (int.TryParse(splitData[0], out outResult)){
            int data1 = int.Parse(splitData[0]);
        }
        //4.IndexOf
        //Ư�� ���ڰ� ���� �ε��� ��ȯ
        //�ش�Ǵ� ���� ó�� �ε����� ��ȯ��
        int charPos = result.IndexOf("_");
        Debug.Log("IndexOf:"+charPos.ToString());
        //5.SubString
        //���ڿ��� �Ϻθ� ��ȯ
        //�Ű������� �Ѱ� : �ش� �Ű����� �ε������� ������
        //�Ű������� �ΰ� : start ~ end-1 ����
        string subString = result.Substring(charPos);
        Debug.Log(subString);


    }
}

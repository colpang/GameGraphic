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
        //문자열 데이터를 바이트로 변환하고 바이트 배열을 이용하여 파일에 저장
        string writeString = "10,20,30,40,고블린";
        byte[] writeByte = Encoding.Default.GetBytes(writeString);
        File.WriteAllBytes(Application.dataPath + "/" + "test.txt",writeByte);
        //바이트 배열을 읽어 문자열로 변환후 콘솔뷰에 출력
        byte[] readBytes = File.ReadAllBytes(Application.dataPath + "/" + "test.txt");
        string readString = Encoding.Default.GetString(readBytes);
        Debug.Log(readString);

        //문자열관련함수
        //1.Trim
        //선행/후행 공백 모두 제거
        string message = " 100,200,300,400 ";
        string result = message.Trim();
        Debug.Log("Trim:"+result);
        //2.Replace
        //특정 문자를 지정한 문자로 대체
        result = message.Replace(",","_");
        Debug.Log("Replace:"+result);
        //3.Split
        //특정 문자를 기준으로 분리, 배열로 반환
        string[] splitData = result.Split("_");
        foreach (string one in splitData)
            Debug.Log(one);
        //문자열을 정수로 변환하려면
        int outResult;
        if (int.TryParse(splitData[0], out outResult)){
            int data1 = int.Parse(splitData[0]);
        }
        //4.IndexOf
        //특정 문자가 나온 인덱스 반환
        //해당되는 가장 처음 인덱스가 반환됨
        int charPos = result.IndexOf("_");
        Debug.Log("IndexOf:"+charPos.ToString());
        //5.SubString
        //문자열의 일부를 반환
        //매개변수가 한개 : 해당 매개변수 인덱스부터 끝까지
        //매개변수가 두개 : start ~ end-1 까지
        string subString = result.Substring(charPos);
        Debug.Log(subString);


    }
}

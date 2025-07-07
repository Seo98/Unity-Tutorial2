using UnityEngine;
using System.Collections.Generic;
public class DynamicArray : MonoBehaviour
{
    /*private object[] array = new object[3];

    void Add(object o)
    {
        var temp = new object[array.Length+1];

        for (int i = 0; i < array.Length; i++)
        {
            temp[i] = array[i];
        }

        array = temp;
        array[array.Length-1] = o;
    }*/

    /*public List<int> abc = new List<int>();
    public List<int> abcd = new List<int>() { 1, 2, 3, 4, 5 };
    public List<int> abcde;

    private void Start()
    {
        abc.Add(10);
        abcd.Add(10);
        abcde.Add(10);
    }*/

    public List<int> list1 = new List<int>();

    private void Start()
    {

        for (int i = 0; i < 10; i++)
        {
            list1.Add(i);
        }
        /*
        list1.Insert(5, 100); // 인덱스 5번에 100 끼워넣기

        list1.Remove(5); // 값 5를 제거
        list1.RemoveAt(5); // 인덱스 5번에 있는 값 제거
        list1.RemoveRange(1,3); // 인덱스 1,3번까지 제거

        list1.Clear(); // 데이터 정상화
        
        list1.RemoveAll(x => x > 5); // 현재 List 안에서 x>5 값은 모두 제거
        list1.Sort(); // 오름차순 정렬
        */

        /*
        // 1 ~ 10까지 로그 하나에 싹 출력해보는법 1 / 2 / 3 / 4 / 5 / 6 / 7 / 8 / 9 / 10
        string str = string.Empty;
        foreach (var x in list1)
        {
            str += x.ToString() + " / ";
        }

        Debug.Log(str);
        */


        if(list1.Contains(10)) // list에서 값 10이라는 값이 있으면 true
        {
            // 값 10이 존재
        }
        else
        {
            // 값 10이 없음
        }









    }



}

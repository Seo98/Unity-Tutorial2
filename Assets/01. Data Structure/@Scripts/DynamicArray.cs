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
        list1.Insert(5, 100); // �ε��� 5���� 100 �����ֱ�

        list1.Remove(5); // �� 5�� ����
        list1.RemoveAt(5); // �ε��� 5���� �ִ� �� ����
        list1.RemoveRange(1,3); // �ε��� 1,3������ ����

        list1.Clear(); // ������ ����ȭ
        
        list1.RemoveAll(x => x > 5); // ���� List �ȿ��� x>5 ���� ��� ����
        list1.Sort(); // �������� ����
        */

        /*
        // 1 ~ 10���� �α� �ϳ��� �� ����غ��¹� 1 / 2 / 3 / 4 / 5 / 6 / 7 / 8 / 9 / 10
        string str = string.Empty;
        foreach (var x in list1)
        {
            str += x.ToString() + " / ";
        }

        Debug.Log(str);
        */


        if(list1.Contains(10)) // list���� �� 10�̶�� ���� ������ true
        {
            // �� 10�� ����
        }
        else
        {
            // �� 10�� ����
        }









    }



}

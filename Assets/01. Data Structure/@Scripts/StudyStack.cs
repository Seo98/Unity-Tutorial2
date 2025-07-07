using System.Collections.Generic;
using UnityEngine;

public class StudyStack : MonoBehaviour
{
    // public Stack<int> stack = new Stack<int>();
    /*
    void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            stack.Push(i); // 1 ~ 10까지 값을 Stack에 추가
        }

        Debug.Log(stack.Pop()); // Last 값을 뽑음
        Debug.Log(stack.Count);

        Debug.Log(stack.Peek()); // 그 다음에 뽑힐 대상을 확인
        Debug.Log(stack.Count);

        Debug.Log(stack.Pop());
        Debug.Log(stack.Count);
    }*/

    public Stack<int> stack = new Stack<int>();
    public int[] array = new int[3] { 1, 2, 3 };
    public int[] array2;

    void Start()
    {
        stack = new Stack<int>(array);

        array2 = stack.ToArray();
    }
}
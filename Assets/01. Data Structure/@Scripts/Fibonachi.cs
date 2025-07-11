using System;
using UnityEngine;

public class Fibonachi : MonoBehaviour
{
    public int n = 7; // 7��° ��

    void Start()
    {
        // ��ǥ �� ã��
        Debug.Log($"{n}��° �Ǻ���ġ ��: {FibonacciFunction(n)}");

        // 0 ~ n��°���� ���
        string result = String.Empty;
        for (int i = 0; i <= n; i++)
            result += FibonacciFunction(i) + " ";

        Debug.Log($"0 ~ {n}��°����: {result}");
    }

    int FibonacciFunction(int n)
    {
        if (n <= 1)
            return n;

        return FibonacciFunction(n - 1) + FibonacciFunction(n - 2);
    }
}

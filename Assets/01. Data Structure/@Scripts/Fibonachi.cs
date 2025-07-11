using System;
using UnityEngine;

public class Fibonachi : MonoBehaviour
{
    public int n = 7; // 7번째 값

    void Start()
    {
        // 목표 값 찾기
        Debug.Log($"{n}번째 피보나치 수: {FibonacciFunction(n)}");

        // 0 ~ n번째까지 출력
        string result = String.Empty;
        for (int i = 0; i <= n; i++)
            result += FibonacciFunction(i) + " ";

        Debug.Log($"0 ~ {n}번째까지: {result}");
    }

    int FibonacciFunction(int n)
    {
        if (n <= 1)
            return n;

        return FibonacciFunction(n - 1) + FibonacciFunction(n - 2);
    }
}

using UnityEngine;

public class StaticArray : MonoBehaviour
{
    public int[] array1; // 선언
    public int[] array2 = { 10, 20, 30, 40, 50 }; // 선언 초기화
    public int[] array3 = new int[5]; // 선언 할당
    public int[] array4 = new int[5] { 10, 20, 30, 40, 50 }; // 선언 할당 초기화 

    public NewData[] data = new NewData[5];

    
}


public class NewData
{
    
}

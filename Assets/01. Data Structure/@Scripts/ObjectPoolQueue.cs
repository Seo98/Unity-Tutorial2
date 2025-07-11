using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    public Queue<GameObject> objQueue = new Queue<GameObject>(); // ������Ʈ���� �� ť

    public GameObject objPrefab; // ������ ������Ʈ
    public Transform parent; // ���� ������ �� �θ� ������Ʈ

    void Start()
    {
        CreateObject();
    }

    private void CreateObject() // ������Ʈ�� �����ϴ� ��� -> Pool�� ä��� ���
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject obj = Instantiate(objPrefab, parent); // ������Ʈ�� �����ϰ�, ���������� parent�� �ڽ����� ����

            EnqueueObject(obj);
        }
    }

    public void EnqueueObject(GameObject newObj) // ����ִ� �Լ�
    {
        objQueue.Enqueue(newObj);
        newObj.SetActive(false); // ������Ʈ�� �۵����� �ʵ��� Active -> false
    }

    public GameObject DequeueObject() // �������� �Լ�
    {
        GameObject obj = objQueue.Dequeue();
        obj.SetActive(true);

        return obj;
    }
}

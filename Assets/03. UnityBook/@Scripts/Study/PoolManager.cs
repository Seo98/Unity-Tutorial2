using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : Singleton<PoolManager>
{
    public ObjectPool<GameObject> pool;
    public GameObject prefab;

    void Awake()
    {
        pool = new ObjectPool<GameObject>(CreateObject, OnGetObject, OnReleaseObject, OnDestroyObject,
                                            defaultCapacity: 10, maxSize: 100);
        // ���� -> �������� -> ����ִ� ���
        // �ʱ�������� / �ִ��������
    }

    private GameObject CreateObject() // ����� ������Ʈ ����
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);

        return obj;
    }

    private void OnGetObject(GameObject obj) // ������Ʈ ��� �� ȣ��(�ʱ�ȭ ��� �����ϸ� ��)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        obj.transform.position = Vector3.zero;
        obj.SetActive(true);
    }

    private void OnReleaseObject(GameObject obj) // ������Ʈ ��ȯ �� ȣ��
    {
        obj.SetActive(false);
    }

    private void OnDestroyObject(GameObject obj) // ������Ʈ �ı� �� ȣ��
    {
        Destroy(obj);
    }
}
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
        // 생성 -> 꺼내쓰고 -> 집어넣는 기능
        // 초기생성갯수 / 최대생성갯수
    }

    private GameObject CreateObject() // 사용할 오브젝트 생성
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);

        return obj;
    }

    private void OnGetObject(GameObject obj) // 오브젝트 사용 시 호출(초기화 라고 생각하면 됨)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        obj.transform.position = Vector3.zero;
        obj.SetActive(true);
    }

    private void OnReleaseObject(GameObject obj) // 오브젝트 반환 시 호출
    {
        obj.SetActive(false);
    }

    private void OnDestroyObject(GameObject obj) // 오브젝트 파괴 시 호출
    {
        Destroy(obj);
    }
}
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        // ī�޶��� ��ġ�� ��ǥ Ʈ������ ��ġ�� ��ġ��Ų��.
        transform.position = target.position;
    }


}

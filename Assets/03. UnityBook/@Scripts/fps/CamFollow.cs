using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        // 카메라의 위치를 목표 트랜스폼 위치에 일치시킨다.
        transform.position = target.position;
    }


}

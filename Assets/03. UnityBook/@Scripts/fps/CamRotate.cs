using System;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float rotSpeed = 200;

    public float mx = 0f;
    public float my = 0f;

    void Update()
    {
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f);

        transform.eulerAngles = new Vector3(-my, mx, 0);




        // Degree 값에 의해 뒤바뀌어짐
        //Vector3 dir = new Vector3(-Mouse_Y, Mouse_X, 0f);
        //transform.eulerAngles += dir * rotSpeed * Time.deltaTime;

        // 쿼너니언 = 알아보기 어렴지만 정확하고 이슈없음(float float float float)
        // 오일러 = 알아보기쉽지만 짐벌락 이슈가 있음 (0~360)

        // transform.rotation << 쿼너티언 값

        /*
        Vector3 rot = transform.eulerAngles; // 현재 회전값을 가져와서 저장
        rot.x = Mathf.Clamp(rot.x, -90f, 90f); // 회전값 제한
        transform.eulerAngles = rot; // 제한된 회전값을 적용
        */

        // transform.eulerAngles = Mathf.Clamp(rot.x, -90f, 90f); << 직접 적용은 불가





    }
}

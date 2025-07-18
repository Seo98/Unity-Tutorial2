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




        // Degree ���� ���� �ڹٲ����
        //Vector3 dir = new Vector3(-Mouse_Y, Mouse_X, 0f);
        //transform.eulerAngles += dir * rotSpeed * Time.deltaTime;

        // ���ʴϾ� = �˾ƺ��� ������� ��Ȯ�ϰ� �̽�����(float float float float)
        // ���Ϸ� = �˾ƺ��⽱���� ������ �̽��� ���� (0~360)

        // transform.rotation << ����Ƽ�� ��

        /*
        Vector3 rot = transform.eulerAngles; // ���� ȸ������ �����ͼ� ����
        rot.x = Mathf.Clamp(rot.x, -90f, 90f); // ȸ���� ����
        transform.eulerAngles = rot; // ���ѵ� ȸ������ ����
        */

        // transform.eulerAngles = Mathf.Clamp(rot.x, -90f, 90f); << ���� ������ �Ұ�





    }
}

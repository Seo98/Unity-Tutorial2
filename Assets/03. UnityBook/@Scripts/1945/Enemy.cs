using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 dir;
    public float speed = 5;

    public GameObject explosionFactory;

    void OnEnable()
    {
        int ranValue = UnityEngine.Random.Range(0, 10);

        if (ranValue < 3) // 30%
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position; // �÷��̾ �ٶ󺸴� ���� ��
            dir.Normalize();
        }
        else // 70%
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        ScoreManager.Instance.Score++;

        // ��ƼŬ ����
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        // �ı� ���
        other.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
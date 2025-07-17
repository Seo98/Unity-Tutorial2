using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class EnemyManager : Singleton<EnemyManager>
{
    public int poolSize = 10;

    //public GameObject[] enemyObjectPool;
    // public Queue<GameObject> enemyObjectPool;
    public List<GameObject> enemyObjectPool;
    public Transform[] spawnPoints;

    public GameObject enemyFactory;


    private float currentTime; // Ÿ�̸�
    private float minTime = 1;
    private float maxTime = 5;
    public float createTime = 1f; // ���� �ֱ�

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        // enemyObjectPool = new Queue<GameObject>();
        enemyObjectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);

            enemyObjectPool.Add(enemy);
            // enemyObjectPool.EnQueue(enemy);
            enemy.SetActive(false);
        }
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime) // ������ �ð��� �� �� ���� ������ ��ġ�� Enemy ����
        {






            currentTime = 0f;
            createTime = Random.Range(minTime, maxTime);

            for (int i = 0; i < poolSize; i++)
            {
                GameObject enemy = enemyObjectPool[i];

                if (!enemy.activeSelf)
                {
                    int ranIndex = Random.Range(0, spawnPoints.Length);
                    Transform spawnPoint = spawnPoints[ranIndex];

                    enemy.transform.position = spawnPoint.position;
                    enemy.SetActive(true);

                    break;
                }
            }

        }
    }
}
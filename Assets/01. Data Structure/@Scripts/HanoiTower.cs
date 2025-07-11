using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3 }
    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefabs;
    public BoardBar[] bars; // L, C, R

    public TextMeshProUGUI CountText;
    public Button answerButton;

    public static GameObject selectedDonut;
    public static bool isSelected;

    private void Awake()
    {
        answerButton.onClick.AddListener(HanoiAnswer);
    }

    IEnumerator Start()
    {
        for (int i = (int)hanoiLevel - 1; i >= 0; i--) // �ݺ������� Level��ŭ ���� ����
        {
            GameObject donut = Instantiate(donutPrefabs[i]); // ���� ����
            donut.transform.position = new Vector3(-5f, 5f, 0); // ���� ���� ��ġ : ���� ����� + ����

            bars[0].PushDonut(donut); // ��� ������ ������ �ش� Bar�� Stack Push

            yield return new WaitForSeconds(1f); // ���������� ����
        }
    }

    public void HanoiAnswer()
    {
        HanoiRoutine((int)hanoiLevel, 0, 1, 2);
    }

    void HanoiRoutine(int n, int from, int temp, int to)
    {
        if (n == 0)
            return;


        if (n == 1)
        {
            Debug.Log("d");
        }
        else
        {
            HanoiRoutine(n - 1, from, to, temp);
        }
    }
}
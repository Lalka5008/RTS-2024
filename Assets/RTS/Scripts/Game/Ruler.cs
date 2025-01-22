using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{
    public Transform cube1; // ������ ���
    public Transform cube2; // ������ ���
    public TMP_Text distanceText; // UI ����� ��� ����������� ����������

    void Update()
    {
        // ��������� ���������� ����� ������
        float distance = Vector3.Distance(cube1.position, cube2.position);

        // ��������� ����� � �����������
        distanceText.text = "����������: " + distance.ToString("F2") + " ������"; // ����������� �� ���� ������ ����� �������
    }
}

using UnityEngine;

public class Wood : Resource
{
    void Awake()
    {
        resourceName = "������";
        maxDurability = 5; // ��������, ����� ������ 5 ���
        Initialize();
    }
}
using UnityEngine;

public class Stone : Resource
{
    void Awake()
    {
        resourceName = "������";
        maxDurability = 3; // ��������, ����� ������ 3 ����
        Initialize();
    }
}
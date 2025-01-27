using UnityEngine;

public abstract class Resource : MonoBehaviour
{
    public string resourceName;
    public int maxDurability; // ������������ ���������� ������
    public int currentDurability; // ������� ���������� ������

    public virtual void Initialize()
    {
        currentDurability = maxDurability;
    }

    // ����� ��� ������ �������
    public virtual bool MineResource()
    {
        if (currentDurability > 0)
        {
            currentDurability--;
            Debug.Log($"������ {resourceName}. �������� ������: {currentDurability}");
            return true;
        }
        else
        {
            Debug.Log($"{resourceName} ��������.");
            DestroyResource();
            return false;
        }
    }

    // ����� ��� ����������� �������
    public virtual void DestroyResource()
    {
        Debug.Log($"{resourceName} ���������.");
        Destroy(gameObject);
    }
}
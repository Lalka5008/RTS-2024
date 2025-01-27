using UnityEngine;

public abstract class Resource : MonoBehaviour
{
    public string resourceName;
    public int maxDurability; // Максимальное количество добычи
    public int currentDurability; // Текущее количество добычи

    public virtual void Initialize()
    {
        currentDurability = maxDurability;
    }

    // Метод для добычи ресурса
    public virtual bool MineResource()
    {
        if (currentDurability > 0)
        {
            currentDurability--;
            Debug.Log($"Добыто {resourceName}. Осталось добыть: {currentDurability}");
            return true;
        }
        else
        {
            Debug.Log($"{resourceName} исчерпан.");
            DestroyResource();
            return false;
        }
    }

    // Метод для уничтожения ресурса
    public virtual void DestroyResource()
    {
        Debug.Log($"{resourceName} уничтожен.");
        Destroy(gameObject);
    }
}
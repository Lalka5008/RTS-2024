using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance; // Singleton для доступа из других скриптов

    public int woodCount = 0;
    public int stoneCount = 0;

    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;

    void Awake()
    {
        UpdateUI();
        // Реализация Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Методы для добавления ресурсов
    public void AddWood(int amount)
    {
        woodCount += amount;
        UpdateUI();
    }

    public void AddStone(int amount)
    {
        stoneCount += amount;
        UpdateUI();
    }

    // Методы для использования ресурсов (если нужно)
    public bool UseWood(int amount)
    {
        if (woodCount >= amount)
        {
            woodCount -= amount;
            UpdateUI();
            return true;
        }
        return false;
    }

    public bool UseStone(int amount)
    {
        if (stoneCount >= amount)
        {
            stoneCount -= amount;
            UpdateUI();
            return true;
        }
        return false;
    }

    // Обновление UI
    void UpdateUI()
    {
        if (woodText != null)
            woodText.text = $"{woodCount}";
        if (stoneText != null)
            stoneText.text = $"{stoneCount}";
    }
}
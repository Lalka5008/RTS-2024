using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UnitUIHandler : MonoBehaviour
{
    public GameObject largeUnitPanel; // Панель для одного юнита
    public TextMeshProUGUI unitName; // Поле имени юнита
    public Image unitIcon; // Иконка юнита
    public Slider unitHealthBar; // Полоса здоровья юнита
    public GameObject smallUnitsGrid; // Панель для сетки
    public GameObject smallUnitPrefab; // Префаб для маленьких юнитов
    public Transform gridParent; // Родительский объект для маленьких юнитов

    private List<GameObject> smallUnitItems = new List<GameObject>(); // Список элементов в сетке

    public void UpdateUI(List<GameObject> selectedUnits)
    {
        ClearSmallUnitGrid(); // Очистить сетку перед обновлением

        if (selectedUnits.Count == 1)
        {
            ShowLargeUnitPanel(selectedUnits[0]);
        }
        else if (selectedUnits.Count > 1)
        {
            ShowSmallUnitsGrid(selectedUnits);
        }
        else
        {
            HideAllPanels();
        }
    }

    private void ShowLargeUnitPanel(GameObject unit)
    {
        largeUnitPanel.SetActive(true);
        smallUnitsGrid.SetActive(false);


        Unit unitData = unit.GetComponent<Unit>();
        if (unitData != null)
        {
            Debug.Log($"Large Unit: {unitData.unitName}, Health: {unitData.currentHealth}/{unitData.maxHealth}");

            unitName.text = unitData.unitName;
            unitIcon.sprite = unitData.unitIcon;
            unitHealthBar.maxValue = unitData.maxHealth;
            unitHealthBar.value = unitData.currentHealth;
        }
        else
        {
            Debug.LogError("Unit data is null! Check if the GameObject has a Unit component.");
        }
    }


    private void ShowSmallUnitsGrid(List<GameObject> selectedUnits)
    {
        largeUnitPanel.SetActive(false);
        smallUnitsGrid.SetActive(true);


        foreach (GameObject unit in selectedUnits)
        {
            Unit unitData = unit.GetComponent<Unit>();
            if (unitData != null)
            {
                GameObject smallUnitItem = Instantiate(smallUnitPrefab, gridParent);
                smallUnitItems.Add(smallUnitItem);

                // Обновляем UI маленького элемента
                Image icon = smallUnitItem.transform.Find("Icon").GetComponent<Image>();
                Slider healthBar = smallUnitItem.transform.Find("HealthBar").GetComponent<Slider>();

                icon.sprite = unitData.unitIcon;
                healthBar.maxValue = unitData.maxHealth;
                healthBar.value = unitData.currentHealth;
            }
        }
    }

    private void HideAllPanels()
    {
        largeUnitPanel.SetActive(false);
        smallUnitsGrid.SetActive(true);

    }

    private void ClearSmallUnitGrid()
    {
        foreach (GameObject item in smallUnitItems)
        {
            Destroy(item);
        }
        smallUnitItems.Clear();
    }
}

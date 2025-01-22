using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{
    public Transform cube1; // Первый куб
    public Transform cube2; // Второй куб
    public TMP_Text distanceText; // UI текст для отображения расстояния

    void Update()
    {
        // Вычисляем расстояние между кубами
        float distance = Vector3.Distance(cube1.position, cube2.position);

        // Обновляем текст с расстоянием
        distanceText.text = "Расстояние: " + distance.ToString("F2") + " юнитов"; // Форматируем до двух знаков после запятой
    }
}

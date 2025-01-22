
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class MiniSliderHitPoints : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI textMeshPro;
    void Update()
    {
        float MaxHealth = slider.maxValue;
        float CurrentHealth = slider.value;
        textMeshPro.text = $"{CurrentHealth}/{MaxHealth}";
    }
}

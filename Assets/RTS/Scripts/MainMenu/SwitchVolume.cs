using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Скрипт для переключения громкости звука через SettingsManager.
/// </summary>
public class SwitchVolume : MonoBehaviour
{
    [SerializeField] private Image _on;        // Изображение для состояния "включено"
    [SerializeField] private Image _off;       // Изображение для состояния "выключено"
    [SerializeField] private MainMenu _whereMusicIs; // Ссылка на MainMenu, где управляется музыка

    private bool isOn = true;

    private void Start()
    {
        // Добавляем слушатель для кнопки
        GetComponent<Button>().onClick.AddListener(OnClickButton);
        UpdateUI();
    }

    /// <summary>
    /// Метод, вызываемый при нажатии кнопки.
    /// </summary>
    private void OnClickButton()
    {
        // Переключаем состояние звука
        isOn = !isOn;

        // Устанавливаем громкость через SettingsManager
        if (SettingsManager.Instance != null)
        {
            SettingsManager.Instance.SetVolume(isOn ? 1f : 0f);
        }
        else
        {
            Debug.LogError("SettingsManager instance is missing.");
        }

        // Обновляем UI
        UpdateUI();
    }

    /// <summary>
    /// Обновляет UI в зависимости от состояния звука.
    /// </summary>
    private void UpdateUI()
    {
        if (_on != null)
        {
            _on.gameObject.SetActive(isOn);
        }
        if (_off != null)
        {
            _off.gameObject.SetActive(!isOn);
        }
    }
}
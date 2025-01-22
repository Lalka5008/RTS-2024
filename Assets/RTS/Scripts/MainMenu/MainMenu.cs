using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Slider volumeSlider;

    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        // Получаем компонент AudioSource
        audioSource = GetComponent<AudioSource>();

        // Инициализируем слайдер громкости из SettingsManager
        if (SettingsManager.Instance != null)
        {
            volumeSlider.value = SettingsManager.Instance.musicVolume;
            UpdateVolume();
        }

        // Добавляем обработчик событий для слайдера
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
    }

    // Update is called once per frame
    private void Update()
    {
        // Обновляем громкость аудио-источника в реальном времени
        if (SettingsManager.Instance != null)
        {
            audioSource.volume = SettingsManager.Instance.musicVolume;
        }
    }

    // Метод для обновления громкости
    public void UpdateVolume()
    {
        if (SettingsManager.Instance != null)
        {
            SettingsManager.Instance.SetVolume(volumeSlider.value);
        }
    }

    // Обработчик событий для слайдера
    private void OnVolumeSliderChanged(float value)
    {
        UpdateVolume();
    }

    // Метод для начала игры
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    // Метод для выхода из игры
    public void ExitGame()
    {
        Debug.Log("GameClosed");
        Application.Quit();
    }
}
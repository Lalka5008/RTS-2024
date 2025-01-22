using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    // Публичное статическое свойство для доступа к экземпляру
    public static SettingsManager Instance { get; private set; }

    public float musicVolume = 1f;
    public bool soundEnabled = true;

    private void Awake()
    {
        // Проверяем, есть ли уже экземпляр SettingsManager
        if (Instance == null)
        {
            // Если нет, то назначаем текущий объект как экземпляр
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume)
    {
        musicVolume = volume;

    }

    public void ToggleSound(bool enabled)
    {
        soundEnabled = enabled;
    }
}
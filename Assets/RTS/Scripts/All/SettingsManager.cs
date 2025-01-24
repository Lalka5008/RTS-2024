using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set; }

    public float musicVolume = 1f;
    public bool soundEnabled = true;
    public int resolutionIndex = 0; // Индекс выбранного разрешения
    public bool isFullScreen = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadSettings();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume)
    {
        musicVolume = volume;
        SaveSettings();
    }

    public void ToggleSound(bool enabled)
    {
        soundEnabled = enabled;
        SaveSettings();
    }

    public void SetResolution(int index)
    {
        resolutionIndex = index;
        SaveSettings();
    }

    public void SetFullScreen(bool fullScreen)
    {
        isFullScreen = fullScreen;
        SaveSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetInt("SoundEnabled", soundEnabled ? 1 : 0);
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
        PlayerPrefs.SetInt("IsFullScreen", isFullScreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        soundEnabled = PlayerPrefs.GetInt("SoundEnabled", 1) == 1;
        resolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);
        isFullScreen = PlayerPrefs.GetInt("IsFullScreen", 1) == 1;
    }
}
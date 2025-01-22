using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    // ��������� ����������� �������� ��� ������� � ����������
    public static SettingsManager Instance { get; private set; }

    public float musicVolume = 1f;
    public bool soundEnabled = true;

    private void Awake()
    {
        // ���������, ���� �� ��� ��������� SettingsManager
        if (Instance == null)
        {
            // ���� ���, �� ��������� ������� ������ ��� ���������
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
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
        // �������� ��������� AudioSource
        audioSource = GetComponent<AudioSource>();

        // �������������� ������� ��������� �� SettingsManager
        if (SettingsManager.Instance != null)
        {
            volumeSlider.value = SettingsManager.Instance.musicVolume;
            UpdateVolume();
        }

        // ��������� ���������� ������� ��� ��������
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
    }

    // Update is called once per frame
    private void Update()
    {
        // ��������� ��������� �����-��������� � �������� �������
        if (SettingsManager.Instance != null)
        {
            audioSource.volume = SettingsManager.Instance.musicVolume;
        }
    }

    // ����� ��� ���������� ���������
    public void UpdateVolume()
    {
        if (SettingsManager.Instance != null)
        {
            SettingsManager.Instance.SetVolume(volumeSlider.value);
        }
    }

    // ���������� ������� ��� ��������
    private void OnVolumeSliderChanged(float value)
    {
        UpdateVolume();
    }

    // ����� ��� ������ ����
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    // ����� ��� ������ �� ����
    public void ExitGame()
    {
        Debug.Log("GameClosed");
        Application.Quit();
    }
}
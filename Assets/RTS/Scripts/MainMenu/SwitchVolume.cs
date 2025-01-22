using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ������ ��� ������������ ��������� ����� ����� SettingsManager.
/// </summary>
public class SwitchVolume : MonoBehaviour
{
    [SerializeField] private Image _on;        // ����������� ��� ��������� "��������"
    [SerializeField] private Image _off;       // ����������� ��� ��������� "���������"
    [SerializeField] private MainMenu _whereMusicIs; // ������ �� MainMenu, ��� ����������� ������

    private bool isOn = true;

    private void Start()
    {
        // ��������� ��������� ��� ������
        GetComponent<Button>().onClick.AddListener(OnClickButton);
        UpdateUI();
    }

    /// <summary>
    /// �����, ���������� ��� ������� ������.
    /// </summary>
    private void OnClickButton()
    {
        // ����������� ��������� �����
        isOn = !isOn;

        // ������������� ��������� ����� SettingsManager
        if (SettingsManager.Instance != null)
        {
            SettingsManager.Instance.SetVolume(isOn ? 1f : 0f);
        }
        else
        {
            Debug.LogError("SettingsManager instance is missing.");
        }

        // ��������� UI
        UpdateUI();
    }

    /// <summary>
    /// ��������� UI � ����������� �� ��������� �����.
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
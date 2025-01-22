using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwitchScreen : MonoBehaviour
{
    private Button _button;
    [SerializeField] private Image _on;
    [SerializeField] private Image _off;
    [SerializeField] private TextMeshProUGUI _text; // Используйте TextMeshProUGUI для UI текста
    public bool isFullScreen = true;
    private bool isOn = false;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClickButton);
        Status();
        FullscreenToggle();
    }

    private void OnClickButton()
    {
        isOn = !isOn;
        Status();
        FullscreenToggle();
    }

    public void FullscreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = !isFullScreen;
    }

    private void Status()
    {
        if (isOn)
        {
            _off.gameObject.SetActive(false);
            _on.gameObject.SetActive(true);
            _text.text = "ON";
        }
        else
        {
            _on.gameObject.SetActive(false);
            _off.gameObject.SetActive(true);
            _text.text = "OFF";
        }
    }
}

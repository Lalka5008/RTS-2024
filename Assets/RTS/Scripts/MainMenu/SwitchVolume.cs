using UnityEngine;
using UnityEngine.UI;

public class SwitchVolume : MonoBehaviour
{
    [SerializeField] private Image _on;       
    [SerializeField] private Image _off;     
    [SerializeField] private MainMenu _mainMenu; 

    private bool isOn = true; 

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickButton);
        UpdateUI();
    }

    private void OnClickButton()
    {

        isOn = !isOn;

        _mainMenu.SetVolume(isOn ? 1f : 0f);

        UpdateUI();
    }

    private void UpdateUI()
    {
        _on.gameObject.SetActive(isOn);
        _off.gameObject.SetActive(!isOn);
    }
}

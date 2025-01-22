using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ResolutionChanger : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown; 

    void Start()
    {
        resolutionDropdown.onValueChanged.AddListener(ChangeResolution);
    }

    void ChangeResolution(int index)
    { 
        switch (index)
        {
            case 0: // 1920x1080
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 1: // 1600x900
                Screen.SetResolution(1600, 900, Screen.fullScreen);
                break;
            case 2: // 1336x768
                Screen.SetResolution(1336, 768, Screen.fullScreen);
                break ;
            case 3: // 1280x720
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
        }
    }
}

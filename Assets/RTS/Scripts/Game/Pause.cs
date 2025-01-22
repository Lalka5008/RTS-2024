using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    bool IsPaused;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>();
    }

    public void PauseTheGame()
    {
        
        Time.timeScale = 0f;
        
    }
    public void UnPauseTheGame()
    {
        Time.timeScale = 1f;
    }
}

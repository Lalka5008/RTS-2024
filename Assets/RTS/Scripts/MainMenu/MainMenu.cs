using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private float musicVolume = 1f;
    private AudioSource AudioSource;

    // Start is called before the first frame update
    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();

        
    }
    private void Update()
    {
        AudioSource.volume = musicVolume;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");

    }
    public void SetVolume(float volume)
    {
        musicVolume = volume;
    }
    
    // Update is called once per frame
    public void ExitGame()
    {
        Debug.Log("GameClosed");
        Application.Quit();        
    }
    

}

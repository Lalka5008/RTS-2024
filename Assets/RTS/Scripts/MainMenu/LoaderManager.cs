using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LoaderManager : MonoBehaviour
{
    public GameObject OnLoad;
    public GameObject DontDestroyOptions;
    public GameObject DontDestroyManagerOptions;
    // Start is called before the first frame update
    void Start()
    {
        OnLoad.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }
    void Awake()
    {
        DontDestroyOnLoad(DontDestroyOptions);
        DontDestroyOnLoad(DontDestroyManagerOptions);
    }
   
}

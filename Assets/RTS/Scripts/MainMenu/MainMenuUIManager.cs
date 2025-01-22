using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    public static MainMenuUIManager Instance;

    private void Awake()
    {
        Instance = this;
    }
}

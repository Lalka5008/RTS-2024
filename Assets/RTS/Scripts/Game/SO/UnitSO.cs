using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[CreateAssetMenu(fileName = "NewUnit", menuName = "Game/Unit")]
public class UnitSO : ScriptableObject
{

    public string Name;
    public float Speed;
    public float Vision;
    public int Health;

    public int PriceFood;
    public int PriceWood;
    public int PriceIron;
    public int PriceStone;

    public void SaveToJson(string filePath)
    {
        string json = JsonUtility.ToJson(this, true);
        File.WriteAllText(filePath, json);
        Debug.Log($"Сохранено в {filePath}");
    }
}   

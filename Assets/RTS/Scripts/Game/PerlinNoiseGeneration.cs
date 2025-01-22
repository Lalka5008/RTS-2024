using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseGeneration : MonoBehaviour
{
    public GameObject[] prefabs;    // Массив префабов (например, камни, деревья)
    public int mapWidth = 100;      // Ширина карты
    public int mapHeight = 100;     // Высота карты
    public float noiseScale = 20f;  // Масштаб шума
    public float threshold = 0.5f;  // Порог шума, при котором объект генерируется

    void Start()
    {
        GenerateObjects();
    }

    void GenerateObjects()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int z = 0; z < mapHeight; z++)
            {
                // Генерация значения шума Перлина
                float xCoord = (float)x / mapWidth * noiseScale;

                float zCoord = (float)z / mapHeight * noiseScale;

                float perlinValue = Mathf.PerlinNoise(xCoord, zCoord);

                // Проверяем, превышает ли значение шума порог
                if (perlinValue > threshold)
                {
                    // Выбираем случайный префаб
                    GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

                    // Создаем объект на карте
                    Vector3 position = new Vector3(x, 0f, z);
                    Instantiate(prefab, position, Quaternion.Euler(0,Random.Range(0, 180),0));
                }
            }
        }
    }
}

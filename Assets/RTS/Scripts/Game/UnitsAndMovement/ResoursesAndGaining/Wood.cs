using UnityEngine;

public class Wood : Resource
{
    void Awake()
    {
        resourceName = "Дерево";
        maxDurability = 5; // Например, можно добыть 5 раз
        Initialize();
    }
}
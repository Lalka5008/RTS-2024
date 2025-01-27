using UnityEngine;

public class Stone : Resource
{
    void Awake()
    {
        resourceName = "Камень";
        maxDurability = 3; // Например, можно добыть 3 раза
        Initialize();
    }
}
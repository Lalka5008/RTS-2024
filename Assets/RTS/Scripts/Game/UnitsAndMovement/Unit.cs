using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public Sprite unitIcon;
    public float currentHealth;
    public float maxHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

}

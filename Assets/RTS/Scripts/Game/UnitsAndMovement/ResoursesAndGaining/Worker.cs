using UnityEngine;
using UnityEngine.AI;

public class Worker : MonoBehaviour
{
    public NavMeshAgent agent;
    public float harvestRange = 2f; // Радиус добычи
    private Resource currentTarget = null;

    void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (currentTarget != null)
        {
            float distance = Vector3.Distance(transform.position, currentTarget.transform.position);
            if (distance <= harvestRange)
            {
                // Начинаем добычу
                bool success = currentTarget.MineResource();
                if (success)
                {
                    // Добавление ресурса в инвентарь
                    if (currentTarget is Wood)
                    {
                        Inventory.Instance.AddWood(1);
                    }
                    else if (currentTarget is Stone)
                    {
                        Inventory.Instance.AddStone(1);
                    }
                }

                // Проверяем, нужно ли продолжать добычу
                if (currentTarget.currentDurability <= 0)
                {
                    currentTarget = null;
                }
            }
        }
    }

    public void SetTarget(Resource target)
    {
        currentTarget = target;
        agent.SetDestination(target.transform.position);
    }
}
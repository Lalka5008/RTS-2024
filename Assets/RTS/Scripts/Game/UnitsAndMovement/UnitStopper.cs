using UnityEngine;
using UnityEngine.AI;

public class UnitStopper : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool isMoving = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isMoving)
        {
            // Проверяем, достиг ли юнит цели
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    // Останавливаем юнита
                    StopMovement();
                }
            }
        }
    }

    public void MoveTo(Vector3 destination)
    {
        agent.SetDestination(destination);
        agent.isStopped = false; // Включаем движение
        isMoving = true;
    }

    public void StopMovement()
    {
        agent.isStopped = true;
        isMoving = false;
    }
}
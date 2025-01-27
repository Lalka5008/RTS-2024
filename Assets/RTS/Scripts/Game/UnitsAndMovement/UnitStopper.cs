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
            // ���������, ������ �� ���� ����
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    // ������������� �����
                    StopMovement();
                }
            }
        }
    }

    public void MoveTo(Vector3 destination)
    {
        agent.SetDestination(destination);
        agent.isStopped = false; // �������� ��������
        isMoving = true;
    }

    public void StopMovement()
    {
        agent.isStopped = true;
        isMoving = false;
    }
}
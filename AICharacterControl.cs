using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]
public class AICharacterControl : MonoBehaviour
{
    public Transform target;    // the target to chase
    private NavMeshAgent agent;
    private ThirdPersonCharacter character;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();

        agent.updateRotation = false; // character handles rotation
        agent.updatePosition = true;
    }

    void Update()
    {
        if (target != null)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);
        }
        else
        {
            agent.isStopped = true;
            character.Move(Vector3.zero, false, false);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}

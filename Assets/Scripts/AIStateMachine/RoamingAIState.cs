using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoamingAIState : AIState
{
    public AIController AIController { get; }

    public RoamingAIState(AIController aIController, AIStateMachine stateMachine) : base(stateMachine)
    {
        AIController = aIController;
    }

    public override void Enable()
    {
        AIController.MoveTo(GetRandomPosRadius(10), HandleMoveToCompleted);
        AIController.Sense.TargetChanged += HandleTargetChanged;
    }

    public override void Disable()
    {
        AIController.Sense.TargetChanged -= HandleTargetChanged;
    }

    void HandleTargetChanged(DamagableComponent target)
    {
        if(target != null)
        {
            AIController.AbortMoveTo();
            ChangeState("Chasing");
        }
    }

    void HandleMoveToCompleted(MoveToCompletedReason reason)
    {
        if (reason != MoveToCompletedReason.Succses)
            return;
        ChangeState("Roaming");
    }
    

    Vector3 GetRandomPosRadius(float radius)
    {
        Vector3 randonDir = Random.insideUnitSphere * radius;
        Vector3 targetPos = AIController.transform.position + randonDir;

        if (NavMesh.SamplePosition(targetPos, out NavMeshHit hit, radius, NavMesh.AllAreas))
            return hit.position;
        else
            return AIController.transform.position;

    }
}

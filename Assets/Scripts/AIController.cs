using UnityEngine;
using UnityEngine.AI;
using System;


public enum MoveToCompletedReason
{
    Success,
    Failure,
    Aborted
}


[RequireComponent(typeof(AISense))]
public class AIController : BaseCharacterController
{
    bool isMoveToCompleted = true;
    int pathPointIndex;

    NavMeshPath path;
    AISense sense;

    public AISense Sense => sense;

    Action<MoveToCompletedReason> moveToCompleted;

    protected override void Awake()
    {
        base.Awake();
        sense = GetComponent<AISense>();

        path = new NavMeshPath();
    }

    public bool MoveTo(Vector3 targetPos, Action<MoveToCompletedReason> complited = null)
    {
       AbortMoveTo();

       moveToCompleted = complited;

        bool hasPath = NavMesh.CalculatePath(transform.position, targetPos, NavMesh.AllAreas, path);

        if (hasPath)
        {
            if (path.corners.Length == 1)
            {
                InvokeMoveToCompleted(MoveToCompletedReason.Failure);
                return true;
            }

            pathPointIndex = 1;
        }

        isMoveToCompleted = !hasPath;

        if (!hasPath)
            InvokeMoveToCompleted(MoveToCompletedReason.Failure);

        return hasPath;
    }

    public void AbortMoveTo()
    {
        InvokeMoveToCompleted(MoveToCompletedReason.Aborted);
    }

    protected virtual void Update()
    {
        if (path.status != NavMeshPathStatus.PathInvalid)
        {
            for (int i = 0; i < path.corners.Length - 1; i++)
                Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
        }

        if (isMoveToCompleted)
            return;

        Vector3 targetPos = path.corners[pathPointIndex];
        Vector3 sourcePos = transform.position;

        targetPos.y = 0;
        sourcePos.y = 0;

        if (Vector3.Distance(sourcePos, targetPos) < 1)
        {
            if (pathPointIndex + 1 >= path.corners.Length)
            {
                InvokeMoveToCompleted(MoveToCompletedReason.Success);
                return;
            }
            pathPointIndex++;
            targetPos = path.corners[pathPointIndex];
            targetPos.y = 0;
        }

        Vector3 direction = (targetPos - sourcePos).normalized;

        SetRotation(Quaternion.LookRotation(direction, transform.up).eulerAngles.y);
        MoveWorld(direction.x, direction.z);
    }

    void InvokeMoveToCompleted(MoveToCompletedReason reason)
    {
        isMoveToCompleted = true;

        Action<MoveToCompletedReason> action = moveToCompleted;
        moveToCompleted = null;
        action?.Invoke(reason);
    }

}

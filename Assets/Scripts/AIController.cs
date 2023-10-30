using System.Collections;
using System.Collections.Generic;
using UnityEditor.EventSystems;
using UnityEngine;
using UnityEngine.AI;
using System;

public enum MoveToComlitedReason
{
    Succses,
    Failure,
    Aborted
}


public class AIController : BaseCharacterController
{
    bool isMoveToCompleted = true;
    int pathPointIndex;
    NavMeshPath path;

    Action<MoveToComlitedReason> MoveToComplited;

    protected override void Awake()
    {
        base.Awake();

        path = new NavMeshPath();
    }

    public bool MoveTo(Vector3 targetPos, Action<MoveToComlitedReason> complited = null)
    {
        if (!isMoveToCompleted)
            InvokeMoveToComplited(MoveToComlitedReason.Aborted);

       MoveToComplited = complited;
       bool hasPath = NavMesh.CalculatePath(transform.position, targetPos, NavMesh.AllAreas, path);

       if (hasPath)
        {
            pathPointIndex = 1;
        }

        isMoveToCompleted = !hasPath;

        if(!hasPath)
        {
            InvokeMoveToComplited(MoveToComlitedReason.Failure);
        }

        print(path.status + " " + path.corners.Length);

        Debug.DrawLine(transform.position, path.corners[0], Color.magenta, 10, false);
        //Debug.Break();

       return hasPath;
    }

    protected virtual void Update()
    {
        if (path.status != NavMeshPathStatus.PathInvalid)
        {
            for(int i = 0; i < path.corners.Length -1; i++)
            {
                Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
            }
        }

        if (isMoveToCompleted)
            return;

        Vector3 targetPos = path.corners[pathPointIndex];
        Vector3 sourcePos = transform.position; 

        targetPos.y = 0;
        sourcePos.y = 0;

        if(Vector3.Distance(sourcePos, targetPos) < 1)
        {
            if(pathPointIndex + 1 >= path.corners.Length)
            {
                InvokeMoveToComplited(MoveToComlitedReason.Succses);
                
                return;
            }
            pathPointIndex++;
            targetPos = path.corners[pathPointIndex];
            targetPos.y = 0; 
        }

        Vector3 direction = (targetPos - sourcePos).normalized;



        MoveWorld(direction.x, direction.z);
    }

    void InvokeMoveToComplited(MoveToComlitedReason reason)
    {
        isMoveToCompleted = true;
        Action<MoveToComlitedReason> action = MoveToComplited;
        MoveToComplited = null;
        action?.Invoke(reason);
    }
}

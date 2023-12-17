using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform upPoint;
    [SerializeField] Transform downPoint;
    [SerializeField] private bool isUp = false;

    private float lerpSpeed = 0.5f;
    private Transform target;

    private void OnCharacterEnter(BaseCharacterController controller)
    {
        if (controller != null)
        {
            controller.gameObject.transform.SetParent(this.gameObject.transform);
            StartCoroutine(nameof(MoveElevator));
        }

    }
    private void OnCharacterExit(BaseCharacterController controller)
    {
        if (controller == null)
        {
            if (Vector3.Distance(transform.position, target.position) > 0.01f)
            {
                StopCoroutine(nameof(MoveElevator));
            }
            controller.gameObject.transform.parent = null;
        }
    }

    IEnumerator MoveElevator()
    {
        if (!isUp)
        {
            target = upPoint;
        }
        else if (isUp)
        {
            target = downPoint;
        }

        while (Vector3.Distance(transform.position, target.position) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime * lerpSpeed);
            isUp = !isUp;
            yield return isUp;
        }

    }
}

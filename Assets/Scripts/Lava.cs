using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    IEnumerator damageRoutine;
    [SerializeField] int damageAmount = 10;

    IEnumerator ContiniousDamage(DamagableComponent damagableComponent)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            damagableComponent.Hp -= damageAmount;
            Debug.Log(damagableComponent.Hp);
        }
    }

    void OnCharacterExit()
    {
        StopCoroutine(damageRoutine);
    }

    void OnCharacterEnter(BaseCharacterController controller)
    {
        StartCoroutine(damageRoutine = ContiniousDamage(controller.gameObject.GetComponent<DamagableComponent>()));
    }
}

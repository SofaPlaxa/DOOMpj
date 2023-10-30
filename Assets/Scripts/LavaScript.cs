using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    IEnumerator damageRoutine;
    [SerializeField] int damageAmount = 10;
    IEnumerator ContiniousDamage(DamagableComponent damagableComponent)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            damagableComponent.Hp -= damageAmount;
            Debug.Log($"{damagableComponent.Hp} current HP");
        }
    }

    void OnCharacterExit()
    {
        StopCoroutine(damageRoutine);
    }

    void OnCharacterEnter(PlayerController controller)
    {
        StartCoroutine(damageRoutine = ContiniousDamage(controller.gameObject.GetComponent<DamagableComponent>()));
    }
}

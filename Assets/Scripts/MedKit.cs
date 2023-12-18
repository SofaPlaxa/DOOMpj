using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] int amountToHeal = 20;
    DamagableComponent damagableComponent;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<DamagableComponent>(out DamagableComponent damagable))
        {
            damagableComponent = collider.GetComponent<DamagableComponent>();
            damagableComponent.Hp += amountToHeal;
            Debug.Log(damagableComponent.Hp);
            Destroy(gameObject);
        }
    }
}
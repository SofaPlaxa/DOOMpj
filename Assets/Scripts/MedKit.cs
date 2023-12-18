using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] int amountToHeal = 20;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<DamagableComponent>(out DamagableComponent damagable))
        {
            damagable = collider.GetComponent<DamagableComponent>();
            damagable.Hp += amountToHeal;
            Debug.Log(damagable.Hp);
            Destroy(gameObject);
        }
    }
}
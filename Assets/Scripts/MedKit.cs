using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] int heal = 20;
    DamagableComponent damagableComponent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<DamagableComponent>(out DamagableComponent hinge))
        {
            damagableComponent = other.gameObject.GetComponent<DamagableComponent>();
            damagableComponent.Hp += heal;
            Debug.Log(damagableComponent.Hp);
            Destroy(gameObject);
        }
    }
}
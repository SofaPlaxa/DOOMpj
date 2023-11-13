using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] UIAim aim;

    public Vector3 targetPos { get; private set; }

    void Update()
    {
        DamagableComponent damagable = EnemyManager.GetFirstVisibleTarget(transform, 3, Affilation.Demon | Affilation.Neutral, 30);

        aim.CanShoot = damagable != null;
    }
}

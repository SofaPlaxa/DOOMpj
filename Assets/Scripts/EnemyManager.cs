using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{
    static HashSet<DamagableComponent> damagableComponents = new HashSet<DamagableComponent>();
    public static IReadOnlyCollection<DamagableComponent> Enemies => damagableComponents;
    public static void RegisterEnemy(DamagableComponent damagable)
    {
        damagableComponents.Add(damagable);
    }

    public static void UnregisterEnemy(DamagableComponent damagable)
    {
        damagableComponents.Remove(damagable);
    }
}

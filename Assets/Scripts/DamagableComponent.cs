using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableComponent : MonoBehaviour
{
    [SerializeField] int hp = 100;
    [SerializeField] Affilation affilation;

    public Affilation Affilation => affilation;

    int currentHp;

    bool isDead;

    private void Start()
    {
        currentHp = hp;
    }

    public bool IsDead => isDead;

    public bool IsAlive => !isDead;

    public int Hp
    {
        get => hp;
        set
        {
            if (isDead) return;
            currentHp = value;

            if (currentHp <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} is dead");
        isDead = true;
    }

    private void OnEnable()
    {
        EnemyManager.RegisterEnemy(this); 
    }

    private void OnDisable()
    {
        EnemyManager.UnregisterEnemy(this);
    }
}

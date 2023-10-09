using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    [SerializeField] int hp = 100;

    int currentHp;

    bool isDead;

    private void Start()
    {
        currentHp = hp;
    }
    public bool IsDead => isDead;

    //public bool IsAlive
    //{
    //    get
    //    {
    //        return !isDead;
    //    }
    //}
    public int Hp
    {
        get => currentHp;
        set
        {
            if (isDead)
                return;

            currentHp = value;

            if (currentHp <= 0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        Debug.Log($"@{gameObject.name} is dead");
        isDead = true;
    }
    
}


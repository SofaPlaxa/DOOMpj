using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward * 100, Color.green);
        foreach(DamagableComponent enemy in EnemyManager.Enemies)
        {
            Vector3 enemyDirection = (enemy.transform.position - transform.position).normalized;
        }

        //if(Physics.Raycast((transform.position, transform.forward, out RaycastHit hit) && hit.collider.TryGetComponent(out DamagableComponent damagable))
        //{
        //    Debug.Log("can shoot");
        //}
        
    }
}

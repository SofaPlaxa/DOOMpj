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
            //print(Mathf.Acos(Vector3.Dot))
        }

        //if(Physics.Raycast((transform.position, transform.forward, out RaycastHit hit) && hit.collider.TryGetComponent(out DamagableComponent damagable))
        //{
        //    Debug.Log("can shoot");
        //}
        
    }
}

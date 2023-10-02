using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] float healAmount = 25;
    GameObject playerCharacter;
    PlayerController player;
    private void Awake()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        player = playerCharacter.GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(player.currentHealth == 100)
        {
            Debug.Log("hi");
            return;
        }
        else
        {
            player.currentHealth = player.currentHealth + healAmount;
            Debug.Log(player.currentHealth);
            Destroy(gameObject);
        }

    }
}

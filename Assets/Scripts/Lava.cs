//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Lava : MonoBehaviour
//{
//    [SerializeField] float lavaDMG = 5;
//    GameObject playerCharacter;
//    PlayerController player;
//    bool inLava;
//    float DPS = 1;
//    void Start()
//    {
//        playerCharacter = GameObject.FindGameObjectWithTag("Player");
//        player = playerCharacter.GetComponent<PlayerController>();
//    }

//    private void Update()
//    {
//        //DPS += Time.deltaTime;
//        if(inLava)
//        {
//            StartCoroutine(Coroutine());
//        }
//    }

//    private void OnTriggerEnter(Collider collision)
//    {
//        inLava = true;
//    }
//    private void OnTriggerExit(Collider other)
//    {
//        inLava = false;
//    }

//    IEnumerator Coroutine()
//    {
//        player.currentHealth = player.currentHealth - lavaDMG;
//        Debug.Log(player.currentHealth);
//        yield return new WaitForSeconds(1);
//    }
//}

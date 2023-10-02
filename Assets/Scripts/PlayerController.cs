using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float forwardForce = 1;
    [SerializeField] float sideForce = 1;
    [SerializeField] float sensitivity = 1;
    [SerializeField] public float currentHealth;
    [SerializeField] float maxHealth = 100;

    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }
    void FixedUpdate()
    {

        float mouseX = Input.GetAxis("Mouse X");
        float rotation = mouseX * sensitivity * Time.fixedDeltaTime;

        transform.Rotate(0, rotation, 0);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 force = transform.forward * vertical * Time.deltaTime * forwardForce;
        force += transform.right * horizontal * Time.fixedDeltaTime * sideForce;

        rb.AddForce(force);
    }
    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }    
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float sensitivity = 1;
    [SerializeField] public float currentHealth;
    [SerializeField] public float maxHealth = 100;

    CharacterController characterController;

    Vector3 surfaceNormal;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        currentHealth = maxHealth;
    }

    float verticalSpeed;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
        moveDirection = transform.TransformDirection(moveDirection) * speed;
        moveDirection = Vector3.ProjectOnPlane(moveDirection, surfaceNormal);


        transform.Rotate(new Vector3(0, mouseX * sensitivity * Time.deltaTime, 0));

        float verticalSpeed = 0;

        if (characterController.isGrounded) 
        {
            verticalSpeed = 0;
        }
        else
        {
            verticalSpeed -= 9.8f * Time.deltaTime;
        }
        characterController.Move((moveDirection * speed + Vector3.up * verticalSpeed) * Time.deltaTime);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.DrawLine(hit.point, hit.point + hit.normal * 10, Color.red);
        surfaceNormal = hit.normal;
    }
}

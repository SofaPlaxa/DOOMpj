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

        Vector3 rotation = new Vector3(0, Input.GetAxis("Mouse X") * sensitivity*Time.deltaTime);
        transform.Rotate(rotation);

        if(characterController.isGrounded)
        {
            verticalSpeed = -0.1f;
        }
        else
        {
            verticalSpeed += Physics.gravity.y * Time.deltaTime;
        }

        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        input = Vector3.ClampMagnitude(input, 1);

        Vector3 velocity = transform.TransformDirection(input) * speed;

        Quaternion slopeRotation = Quaternion.FromToRotation(Vector3.up, surfaceNormal);
        Vector3 adjustedVelocity = slopeRotation * velocity;

        velocity = adjustedVelocity.y < 0 ? adjustedVelocity : velocity; 

        velocity = adjustedVelocity.y < 0 ? (adjustedVelocity.y == -3 ? Vector3.zero : adjustedVelocity) : velocity;

        velocity.y += verticalSpeed;

        characterController.Move(velocity * Time.deltaTime);
        //float mouseX = Input.GetAxis("Mouse X");
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        //Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        //moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
        //moveDirection = transform.TransformDirection(moveDirection) * speed;
        //moveDirection = Vector3.ProjectOnPlane(moveDirection, surfaceNormal);


        //transform.Rotate(new Vector3(0, mouseX * sensitivity * Time.deltaTime, 0));

        //float verticalSpeed = 0;

        //if (characterController.isGrounded) 
        //{
        //    verticalSpeed = 0;
        //}
        //else
        //{
        //    verticalSpeed -= 9.8f * Time.deltaTime;
        //}
        //characterController.Move((moveDirection * speed + Vector3.up * verticalSpeed) * Time.deltaTime);

        //if (currentHealth > maxHealth)
        //{
        //    currentHealth = maxHealth;
        //}
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.DrawLine(hit.point, hit.point + hit.normal * 10, Color.red);
        surfaceNormal = hit.normal;
    }
}

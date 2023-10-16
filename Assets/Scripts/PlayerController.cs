using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float sensitivity = 1;
    [SerializeField] public float currentHealth;
    [SerializeField] public float maxHealth = 100;

    CharacterController characterController;

    Vector3 surfaceNormal;
    GameObject floor;
    GameObject Floor
    {
        get => floor;
        set
        {
            if (floor != value)
            {
                if (floor != null)
                    floor.SendMessage("OnCharacterExit", this, SendMessageOptions.DontRequireReceiver);
                if (value != null)
                    value.SendMessage("OnCharacterEnter", this, SendMessageOptions.DontRequireReceiver);

            }
            floor = value;
        }
    }
    

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

        GroundCheck();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.DrawLine(hit.point, hit.point + hit.normal * 10, Color.red);
        surfaceNormal = hit.normal;
    }
    
    void GroundCheck()
    {
        if (Physics.Linecast(
            transform.position,
            transform.position + Vector3.down * (characterController.height / 2 + 0.1f),
            out RaycastHit hit))
        {
            Floor = hit.collider.gameObject;
            Floor.SendMessage("OnCharacterStay",this, SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            Floor = null;
        }
    }


}

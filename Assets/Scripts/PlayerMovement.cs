using Unity.VisualScripting;
using UnityEngine;

public class PlayerM : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 2f;
    Vector3 externalForce;
    public float pushForce = 10f;

    public Vector3 dir;

    float hzInput, vInput;
    CharacterController controller;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        GetDirectionAndMove();
        ApplyGravityAndJump();
        ApplyExternalForce();
    }
    void ApplyExternalForce()
    {
        externalForce = Vector3.Lerp(externalForce, Vector3.zero, Time.deltaTime * 2f);
        controller.Move(externalForce * Time.deltaTime);
    }
    public void ApplyForce(Vector3 direction)
    {
        externalForce = direction * pushForce;
    }

    void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        dir = transform.right * hzInput + transform.forward * vInput;

        controller.Move(dir * speed * Time.deltaTime);
    }

    void ApplyGravityAndJump()
    {
        isGrounded = Physics.CheckSphere(transform.position + Vector3.down * 1f, 0.3f, LayerMask.GetMask("Ground"));

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("HIT: " + hit.gameObject.name);

        if (hit.gameObject.CompareTag("Pendulum"))
        {
            Debug.Log("Pendulum hit!");

            Vector3 pushDir = (transform.position - hit.transform.position).normalized;
            ApplyForce(pushDir);
        }
    }
}
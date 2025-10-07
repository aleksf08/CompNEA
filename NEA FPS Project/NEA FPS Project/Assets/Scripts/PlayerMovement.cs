using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;  
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    CharacterController controller;

    Vector3 velocity;

    bool isGrounded;
    bool isMoving;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);



    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        //Grounded check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Reset velocity if grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Getting inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Creating movement vector
        Vector3 move = transform.right * x + transform.forward * z; //(right - red axis) + (forward - blue axis)

        //Moving the player
        controller.Move(move * speed * Time.deltaTime);

        //Jump check
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //Jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Falling
        velocity.y += gravity * Time.deltaTime;

        //Execute jump
        controller.Move(velocity * Time.deltaTime);

        //Check if player is moving
        if (lastPosition != transform.position && isGrounded == true)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        lastPosition = transform.position;
        




    }
}

using Unity.Netcode;
using UnityEngine;


public class MovementNetworkController : NetworkBehaviour
{
    public NetworkVariable<Vector3> Position = new();
    public NetworkVariable<Quaternion> Rotation = new();

    [SerializeField] private float thrustForce = 0;
    [SerializeField] private float strafeForce = 0;
    [SerializeField] private float verticalForce = 0;
    [SerializeField] private float rotationSpeed = 0;

    [SerializeField] private Rigidbody rb;


    [Rpc(SendTo.Server)]
    void SubmitPositionRequestServerRpc(Vector3 position, Quaternion rotation, RpcParams rpcParams = default)
    {
        Position.Value = position;
        Rotation.Value = rotation;

    }


    private void Start()
    {
        rb.linearDamping = 1f;
        rb.angularDamping = 1f;
    }

    void Update()
    {
        if (IsOwner && !IsServer)
        {
            //float moveX = Input.GetAxis("Horizontal");
            //float moveZ = Input.GetAxis("Vertical");
            //float moveY = 0f;

            //if (Input.GetKey(KeyCode.Space)) // Fly up
            //{
            //    moveY = 1f;
            //}
            //else if (Input.GetKey(KeyCode.LeftShift)) // Fly down
            //{
            //    moveY = -1f;
            //}

            DoMovement();
            DoRotation();


            //Vector3 movement = new Vector3(moveX, moveY, moveZ) * 5 * Time.deltaTime;
            //transform.Translate(movement, Space.World);

            //float tiltAmountZ = moveX * -15f;
            ////float tiltAmountX = 0;
            //float tiltAmountX = moveY * -15f;
            //Quaternion targetRotation = Quaternion.Euler(tiltAmountX, transform.rotation.eulerAngles.y, tiltAmountZ);
            //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);

            SubmitPositionRequestServerRpc(transform.position, transform.rotation);
        }


        if (IsServer)
        {
            transform.position = Position.Value;
            transform.rotation = Rotation.Value;

        }
    }
    void DoMovement()
    {
        float move = Input.GetAxis("Vertical");
        rb.AddForce(transform.forward * move * thrustForce, ForceMode.Force);

        float strafe = Input.GetAxis("Horizontal");
        rb.AddForce(transform.right * strafe * strafeForce, ForceMode.Force);


        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * verticalForce, ForceMode.Force);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(-transform.up * verticalForce, ForceMode.Force);
        }

    }

    void DoRotation()
    {
        float pitch = 0f;
        float yaw = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            yaw = -1f;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            yaw = 1f;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            pitch = -1f;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            pitch = 1f;
        }

        rb.AddTorque(transform.up * yaw * rotationSpeed, ForceMode.Force);
        rb.AddTorque(transform.right * pitch * rotationSpeed, ForceMode.Force);

        Quaternion targetRotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        Quaternion currentRotation = transform.rotation;

        rb.rotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * 2f);

    }
}



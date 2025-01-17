using TMPro;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Analytics;


public class MovementNetworkController : NetworkBehaviour
{
    public NetworkVariable<Vector3> Position = new();
    public NetworkVariable<Quaternion> Rotation = new();
    public NetworkVariable<FixedString64Bytes> PlayerName = new();
    public NetworkVariable<int> PlayerColourID = new();

    [SerializeField] private float thrustForce = 0;
    [SerializeField] private float strafeForce = 0;
    [SerializeField] private float verticalForce = 0;
    [SerializeField] private float rotationSpeed = 0;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private Material materialBlue;
    [SerializeField] private Material materialOrange;
    [SerializeField] private Material materialGreen;

    [SerializeField] private MeshRenderer[] playerMeshes;

    [SerializeField] private TextMeshPro playerName;

    private int playerColourID;

    [SerializeField] private Camera cam;


    [Rpc(SendTo.Server)]
    void SubmitPositionRequestServerRpc(Vector3 position, Quaternion rotation, RpcParams rpcParams = default)
    {
        Position.Value = position;
        Rotation.Value = rotation;

    }

    [Rpc(SendTo.Server)]
    void SubmitPlayerInfoServerRpc(FixedString64Bytes name, int colourID)
    {
        PlayerName.Value = name;
        PlayerColourID.Value = colourID;
    }


    private void Start()
    {
        //if (IsOwner)
        //{
        //    PlayerName.Value = PlayerPrefs.GetString("Name");
        //    PlayerColourID.Value = PlayerPrefs.GetInt("Colour");
        //}
        //else
        //{
        //    Debug.Log("Not the Owner");
        //}


        ApplyPlayerValues();
    }

    void ApplyPlayerValues()
    {
        cam = Camera.main;

        playerMeshes = GetComponentsInChildren<MeshRenderer>();

        playerName.text = PlayerName.Value.ToString();
        playerColourID = PlayerColourID.Value;

        Debug.Log(playerColourID);
        switch(playerColourID)
        {
            case 1:
                ChangeMaterial(materialBlue);
                break;
            case 2:
                ChangeMaterial(materialOrange);
                break;
            case 3:
                ChangeMaterial(materialGreen);
                break;
        }

    }

    void ChangeMaterial(Material mat)
    {
        foreach (MeshRenderer renderer in playerMeshes)
        {
            if (renderer.CompareTag("IgnoreMaterialChange"))
            {
                continue;
            }

            renderer.material = mat;
        }
    }

    void Update()
    {
        

        playerName.gameObject.transform.LookAt(cam.transform);
        playerName.gameObject.transform.Rotate(0, 180, 0);



        if (IsOwner && !IsServer)
        {

            DoMovement();
            DoRotation();

            SubmitPositionRequestServerRpc(transform.position, transform.rotation);
        }


        if (IsServer)
        {
            transform.position = Position.Value;
            transform.rotation = Rotation.Value;

        }
        else if (!IsOwner)
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

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            SubmitPlayerInfoServerRpc(PlayerPrefs.GetString("Name"), PlayerPrefs.GetInt("Colour"));
            cam.enabled = true;

        }
        else
        {
            cam.enabled = false;
        }

        PlayerName.OnValueChanged += (oldValue, newValue) => { playerName.text = newValue.ToString(); };
        PlayerColourID.OnValueChanged += (oldValue, newValue) => { ApplyPlayerValues(); };
    }
}



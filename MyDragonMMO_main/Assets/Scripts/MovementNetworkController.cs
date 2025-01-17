using TMPro;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Analytics;


public class MovementNetworkController : NetworkBehaviour
{
    //    public NetworkVariable<Vector3> Position = new();
    //    public NetworkVariable<Quaternion> Rotation = new();
    //    public NetworkVariable<FixedString64Bytes> PlayerName = new();
    //    public NetworkVariable<int> PlayerColourID = new();
    //    public NetworkVariable<Color> PlayerColour = new();

    //    [SerializeField] private float thrustForce = 0;
    //    [SerializeField] private float strafeForce = 0;
    //    [SerializeField] private float verticalForce = 0;
    //    [SerializeField] private float rotationSpeed = 0;

    //    [SerializeField] private Rigidbody rb;

    //    [SerializeField] private Material materialBlue;
    //    [SerializeField] private Material materialOrange;
    //    [SerializeField] private Material materialGreen;
    //    [SerializeField] private Material materialCustom;

    //    [SerializeField] private MeshRenderer[] playerMeshes;

    //    [SerializeField] private TextMeshPro playerName;

    //    private int playerColourID;

    //    [SerializeField] private Camera cam;


    //    [Rpc(SendTo.Server)]
    //    void SubmitPositionRequestServerRpc(Vector3 position, Quaternion rotation, RpcParams rpcParams = default)
    //    {
    //        Position.Value = position;
    //        Rotation.Value = rotation;

    //    }

    //    [Rpc(SendTo.Server)]
    //    void SubmitPlayerInfoServerRpc(FixedString64Bytes name, int colourID, Color colour)
    //    {
    //        PlayerName.Value = name;
    //        PlayerColourID.Value = colourID;
    //        PlayerColour.Value = colour;
    //    }


    //    private void Start()
    //    {
    //        SetRandomPlayerPosition();

    //        //if (IsOwner)
    //        //{
    //        //    PlayerName.Value = PlayerPrefs.GetString("Name");
    //        //    PlayerColourID.Value = PlayerPrefs.GetInt("Colour");
    //        //}
    //        if (IsOwner && !IsServer)
    //        {
    //            PlayerColour.Value = materialCustom.color;
    //        }

    //        ApplyPlayerValues();
    //    }

    //    void ApplyPlayerValues()
    //    {
    //        cam = Camera.main;

    //        playerMeshes = GetComponentsInChildren<MeshRenderer>();

    //        playerName.text = PlayerName.Value.ToString();
    //        playerColourID = PlayerColourID.Value;
    //        //playerName.text = PlayerPrefs.GetString("Name");
    //        //playerColourID = PlayerPrefs.GetInt("Colour");

    //        Debug.Log(playerColourID);
    //        switch(playerColourID)
    //        {
    //            case 0:
    //                ChangeColour(PlayerColour.Value);
    //                break;
    //            case 1:
    //                ChangeColour(materialBlue.color);
    //                break;
    //            case 2:
    //                ChangeColour(materialOrange.color);
    //                break;
    //            case 3:
    //                ChangeColour(materialGreen.color);
    //                break;
    //        }

    //    }

    //    void ChangeMaterial(Material mat)
    //    {
    //        foreach (MeshRenderer renderer in playerMeshes)
    //        {
    //            if (renderer.CompareTag("IgnoreMaterialChange"))
    //            {
    //                continue;
    //            }

    //            renderer.material = mat;
    //            //renderer.material.color = PlayerColour.Value;
    //        }
    //    }
    //    void ChangeColour(Color color)
    //    {
    //        foreach (MeshRenderer renderer in playerMeshes)
    //        {
    //            if (renderer.CompareTag("IgnoreMaterialChange"))
    //            {
    //                continue;
    //            }

    //            //renderer.material = mat;
    //            renderer.material.color = color;
    //        }
    //    }


    //    void Update()
    //    {


    //        playerName.gameObject.transform.LookAt(cam.transform);
    //        playerName.gameObject.transform.Rotate(0, 180, 0);



    //        if (IsOwner && !IsServer)
    //        {

    //            DoMovement();
    //            DoRotation();

    //            SubmitPositionRequestServerRpc(transform.position, transform.rotation);
    //        }


    //        if (IsServer)
    //        {
    //            transform.position = Position.Value;
    //            transform.rotation = Rotation.Value;

    //        }
    //        else if (!IsOwner)
    //        {
    //            transform.position = Position.Value;
    //            transform.rotation = Rotation.Value;
    //        }

    //    }

    //    void SetRandomPlayerPosition()
    //    {
    //        float xPos = Random.Range(-20.0f, 20.0f);
    //        float zPos = Random.Range(-20.0f, 20.0f);
    //        Vector3 newPosition = new Vector3(xPos, 10f, zPos);

    //        if (IsOwner)
    //        {
    //            transform.position = newPosition;
    //        }
    //    }

    //    void DoMovement()
    //    {
    //        float move = Input.GetAxis("Vertical");
    //        rb.AddForce(transform.forward * move * thrustForce * Time.deltaTime, ForceMode.Force);

    //        float strafe = Input.GetAxis("Horizontal");
    //        rb.AddForce(transform.right * strafe * strafeForce * Time.deltaTime, ForceMode.Force);


    //        if (Input.GetKey(KeyCode.Space))
    //        {
    //            rb.AddForce(transform.up * verticalForce * Time.deltaTime, ForceMode.Force);
    //        }
    //        else if (Input.GetKey(KeyCode.LeftShift))
    //        {
    //            rb.AddForce(-transform.up * verticalForce * Time.deltaTime, ForceMode.Force);
    //        }

    //    }

    //    void DoRotation()
    //    {
    //        float pitch = 0f;
    //        float yaw = 0f;

    //        if (Input.GetKey(KeyCode.A))
    //        {
    //            yaw = -1f;
    //        }
    //        else if(Input.GetKey(KeyCode.D))
    //        {
    //            yaw = 1f;
    //        }


    //        if (Input.GetKey(KeyCode.Space))
    //        {
    //            pitch = -1f;
    //        }
    //        else if (Input.GetKey(KeyCode.LeftShift))
    //        {
    //            pitch = 1f;
    //        }

    //        rb.AddTorque(transform.up * yaw * rotationSpeed * Time.deltaTime, ForceMode.Force);
    //        rb.AddTorque(transform.right * pitch * rotationSpeed * Time.deltaTime, ForceMode.Force);

    //        Quaternion targetRotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    //        Quaternion currentRotation = transform.rotation;

    //        rb.rotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * 2f);

    //    }

    //    public override void OnNetworkSpawn()
    //    {
    //        Debug.Log("Player Spawn");

    //        if (IsOwner)
    //        {
    //            SubmitPlayerInfoServerRpc(PlayerPrefs.GetString("Name"), PlayerPrefs.GetInt("Colour"), materialCustom.color);
    //            cam.enabled = true;
    //            cam.GetComponent<AudioListener>().enabled = true;

    //        }
    //        else
    //        {
    //            cam.enabled = false;
    //            cam.GetComponent<AudioListener>().enabled = false;
    //        }

    //        playerName.text = PlayerName.Value.ToString();
    //        playerColourID = PlayerColourID.Value;
    //        //ApplyPlayerValues();

    //        PlayerName.OnValueChanged += (oldValue, newValue) => { playerName.text = newValue.ToString(); };
    //        PlayerColourID.OnValueChanged += (oldValue, newValue) => { playerColourID = newValue; };
    //        PlayerColour.OnValueChanged += (oldValue, newValue) => { ChangeColour(newValue); };
    //    }
}



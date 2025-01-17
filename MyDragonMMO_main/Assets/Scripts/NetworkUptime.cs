using TMPro;
using Unity.Netcode;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Assertions;
public class NetworkUptime : NetworkBehaviour
{
    //    private NetworkVariable<float> ServerUptimeNetworkVariable = new NetworkVariable<float>();
    //    private float last_t = 0.0f;


    //    [SerializeField] private TextMeshProUGUI uptimeText;
    //    [SerializeField] private TextMeshProUGUI connectedClientsText;
    //    [SerializeField] private TextMeshProUGUI deviceTypeText;

    //    [SerializeField] private Canvas canvas;
    //    private bool isCanvasOn;

    //    private int connectedClientsAmount = 0;
    //    private FixedString64Bytes deviceType = new FixedString64Bytes();




    //    private void Start()
    //    {
    //        Assert.IsNotNull(uptimeText);
    //        Assert.IsNotNull(connectedClientsText);
    //        Assert.IsNotNull(deviceTypeText);


    //        canvas.enabled = false;
    //        isCanvasOn = false;
    //    }
    //    public override void OnNetworkSpawn()
    //    {
    //        if (IsServer)
    //        {
    //            ServerUptimeNetworkVariable.Value = 0.0f;
    //            Debug.Log("Server's uptime var initialized to: " + ServerUptimeNetworkVariable.Value);
    //            deviceType = "Server";
    //        }

    //        if(IsClient)
    //        {
    //            deviceType = "Client";
    //        }
    //    }


    //    void Update()
    //    {
    //        connectedClientsAmount = NetworkManager.Singleton.ConnectedClients.Count;


    //        var t_now = Time.time;
    //        if (IsServer)
    //        {
    //            ServerUptimeNetworkVariable.Value = ServerUptimeNetworkVariable.Value + 0.1f;
    //            if (t_now - last_t > 0.5f)
    //            {
    //                last_t = t_now;
    //                Debug.Log("Server uptime var has been updated to: " + ServerUptimeNetworkVariable.Value);

    //                deviceTypeText.text = deviceType.ToString();
    //                uptimeText.text = "Uptime: " + ServerUptimeNetworkVariable.Value.ToString();
    //                connectedClientsText.text = "ConnectedClients: " + connectedClientsAmount.ToString();
    //            }
    //        }


    //        if (!IsServer)
    //        {
    //            deviceTypeText.text = deviceType.ToString();
    //            uptimeText.text = "Uptime: " + ServerUptimeNetworkVariable.Value.ToString();
    //            connectedClientsText.text = "ConnectedClients: " + connectedClientsAmount.ToString();

    //        }

    //        if(Input.GetKey(KeyCode.F3) && !isCanvasOn)
    //        {
    //            canvas.enabled = true;
    //            isCanvasOn = true;
    //        }
    //        else if (Input.GetKey(KeyCode.F3) && isCanvasOn)
    //        {
    //            canvas.enabled= false;
    //            isCanvasOn = false;
    //        }


    //    }
}

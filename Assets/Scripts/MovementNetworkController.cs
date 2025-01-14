using Unity.Netcode;
using UnityEngine;


public class MovementNetworkController : NetworkBehaviour
{
    public NetworkVariable<Vector3> Position = new();


    [Rpc(SendTo.Server)]
    void SubmitPositionRequestServerRpc(Vector3 position, RpcParams rpcParams = default) => Position.Value = position;


    void Update()
    {
        if (IsOwner && !IsServer)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            float moveY = 0f;

            if (Input.GetKey(KeyCode.Space)) // Fly up
            {
                moveY = 1f;
            }
            else if (Input.GetKey(KeyCode.LeftShift)) // Fly down
            {
                moveY = -1f;
            }


            Vector3 movement = new Vector3(moveX, moveY, moveZ) * 5 * Time.deltaTime;
            transform.Translate(movement, Space.World);
            SubmitPositionRequestServerRpc(transform.position);
        }


        if (IsServer)
            transform.position = Position.Value;
    }
}

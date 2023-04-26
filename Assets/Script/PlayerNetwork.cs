using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{

    private NetworkVariable<int> randomNum = new NetworkVariable<int>(1);
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Debug.Log($"Owner: {OwnerClientId} {randomNum.Value}" );
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.T))
        {
            randomNum.Value = Random.Range(0, 100);
        }
        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDir.z = +1f;
        if (Input.GetKey(KeyCode.S)) moveDir.z = -1f;
        if (Input.GetKey(KeyCode.D)) moveDir.x = +1f;
        if (Input.GetKey(KeyCode.A)) moveDir.x = -1f;

        float moveSpeed = 3f;
        transform.position += moveDir * (moveSpeed * Time.deltaTime);
    }
    
}

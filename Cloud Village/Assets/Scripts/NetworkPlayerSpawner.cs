using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;
    private PhotonView pView;
    public int numberInWorld = 0;
    // 
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
        pView = spawnedPlayerPrefab.GetComponent<PhotonView>();

        numberInWorld = pView.ViewID;

        Debug.Log(numberInWorld);

        //this would be where to change colour or add number to spawnedPlayerPrefab
    }

    // 
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}

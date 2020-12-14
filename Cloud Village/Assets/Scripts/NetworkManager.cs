using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    // Update is called once per frame
    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try Connect to Server...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server."); 
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom("Village 1",roomOptions,TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a Room");
        base.OnJoinedRoom();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A New Player joined the Room");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}

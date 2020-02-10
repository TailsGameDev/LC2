using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class UserDataManager : PlayFabIDConsumer
{

    UserData userData;

    UserDataNetworkPusher userDataNetworkPusher;

    UserDataNetworkPuller userDataNetworkPuller;

    public delegate void OnUserDataPulledFromServer();
    public event OnUserDataPulledFromServer onUserDataPulledFromServer;

    public UserDataManager()
    {
        userData = new UserData();
        userDataNetworkPusher = new UserDataNetworkPusher();
        userDataNetworkPuller = new UserDataNetworkPuller(this);
    }

    public string GetPieceOfDataLocally(string key)
    {
        return userData.GetData(key);
    }


    public void StorePieceOfDataLocally(string key, string value)
    {
        userData.Store(key, value);
    }
   

    public void PushAllDataToServer()
    {
        userDataNetworkPusher.PushUserData(userData);
    }


    public void PullUserDataFromServer()
    {
        userDataNetworkPuller.PullUserDataFromServer( base.GetPlayFabId() );
    }

    public void PullUserDataFromServerCallback(Dictionary<string, string> data)
    {
        SetAllUserDataAndNotify(data);
    }

    void SetAllUserDataAndNotify(Dictionary<string, string> data)
    {
        this.userData.SetData(data);
        onUserDataPulledFromServer?.Invoke();
    }

}
